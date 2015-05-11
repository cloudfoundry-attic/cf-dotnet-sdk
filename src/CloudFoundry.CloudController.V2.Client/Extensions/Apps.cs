namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Http;
    using CloudFoundry.CloudController.Common.PushTools;
    using CloudFoundry.CloudController.V2.Client.Data;
    using Newtonsoft.Json;

    public partial class AppsEndpoint
    {
        private const int StepCount = 7;
        private static readonly TimeSpan DefaultUploadTimeout = new TimeSpan(0, 30, 0);

        /// <summary>
        /// Event that is raised on specific parts of the push process.
        /// </summary>
        public event EventHandler<PushProgressEventArgs> PushProgress;

        /// <summary>
        /// Pushes an application to the cloud.
        /// <remarks>
        /// This method is only available on the .NET 4.5 framework. 
        /// Calling this method from a Windows Phone App or a Windows App will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// <param name="appGuid">Application guid</param>
        /// <param name="appPath">Path of origin from which the application will be deployed</param>
        /// <param name="startApplication">True if the app should be started after upload is complete, false otherwise</param>
        public async Task Push(Guid appGuid, string appPath, bool startApplication)
        {
            if (appPath == null)
            {
                throw new ArgumentNullException("appPath");
            }

            IAppPushTools pushTools = new AppPushTools();
            int usedSteps = 1;

            // Step 1 - Check if application exists
            this.TriggerPushProgressEvent(usedSteps, "Checking if application exists");
            RetrieveAppResponse app = await this.Client.Apps.RetrieveApp(appGuid);

            usedSteps += 1;

            // Step 2 - Compute fingerprints for local files
            this.TriggerPushProgressEvent(usedSteps, "Calculating file fingerprints ...");
            Dictionary<string, List<FileFingerprint>> fingerprints = await pushTools.GetFileFingerprints(appPath, this.Client.CancellationToken);
            if (this.CheckCancellation())
            {
                return;
            }

            usedSteps += 1;

            // Step 3 - Compare fingerprints of local files with what the server has
            this.TriggerPushProgressEvent(usedSteps, "Comparing file fingerprints ...");
            string[] neededFiles = await this.FilterExistingFiles(fingerprints);
            if (this.CheckCancellation())
            {
                return;
            }

            usedSteps += 1;

            // Step 4 - Zip all needed files and get a stream back from the PushTools
            this.TriggerPushProgressEvent(usedSteps, "Creating zip package ...");
            using (Stream zippedPayload = await pushTools.GetZippedPayload(appPath, neededFiles, this.Client.CancellationToken))
            {
                if (this.CheckCancellation())
                {
                    return;
                }

                usedSteps += 1;

                // Step 5 - Upload zip to CloudFoundry ...
                this.TriggerPushProgressEvent(usedSteps, "Uploading zip package ...");
                UriBuilder uploadEndpoint = new UriBuilder(this.Client.CloudTarget.AbsoluteUri);
                uploadEndpoint.Path = string.Format(CultureInfo.InvariantCulture, "/v2/apps/{0}/bits", appGuid.ToString());

                List<FileFingerprint> fingerPrintList = fingerprints.Values.SelectMany(list => list).ToList();

                string serializedFingerprints = JsonConvert.SerializeObject(fingerPrintList);
                SimpleHttpResponse uploadResult = await this.UploadZip(uploadEndpoint.Uri, zippedPayload, serializedFingerprints);
                if (this.CheckCancellation())
                {
                    return;
                }

                usedSteps += 1;
            }

            if (startApplication)
            {
                // Step 6 - Start Application
                UpdateAppRequest updateApp = new UpdateAppRequest()
                {
                    State = "STARTED"
                };
                UpdateAppResponse response = await this.UpdateApp(appGuid, updateApp);
                if (this.CheckCancellation())
                {
                    return;
                }

                usedSteps += 1;
            }

            // Step 7 - Done
            this.TriggerPushProgressEvent(usedSteps, "Application {0} pushed successfully", app.Name);
        }

        /// <summary>
        /// Triggers the PushProgress event
        /// </summary>
        /// <param name="currentStep">Current progress step</param>
        /// <param name="message">Message describing push progress</param>
        /// <param name="formatParameters">Format parameters for the message</param>
        private void TriggerPushProgressEvent(int currentStep, string message, params string[] formatParameters)
        {
            this.TriggerPushProgressEvent(currentStep, string.Format(CultureInfo.InvariantCulture, message, formatParameters));
        }

        /// <summary>
        /// Triggers the PushProgress event
        /// </summary>
        /// <param name="currentStep">Current progress step</param>
        /// <param name="message">Message describing push progress</param>
        private void TriggerPushProgressEvent(int currentStep, string message)
        {
            if (this.PushProgress != null)
            {
                this.PushProgress(
                    this,
                    new PushProgressEventArgs()
                    {
                        Message = message,
                        Percent = (int)(((double)currentStep / (double)StepCount) * 100)
                    });
            }
        }

        /// <summary>
        /// Helper method that checks the cancellation token and triggers 
        /// the push progress event if cancellation was requested.
        /// </summary>
        /// <returns>True if cancellation was requested, false otherwise.</returns>
        private bool CheckCancellation()
        {
            if (this.Client.CancellationToken.IsCancellationRequested)
            {
                this.TriggerPushProgressEvent(StepCount, "Push cancelled");
                return true;
            }

            return false;
        }

        /// <summary>
        /// Uploads a stream to CloudFoundry via HTTP
        /// </summary>
        /// <param name="uploadUri">Uri to upload to</param>
        /// <param name="zipStream">The compressed stream to upload</param>
        /// <param name="resources">The json payload describing the files of the app</param>
        /// <returns></returns>
        private async Task<SimpleHttpResponse> UploadZip(Uri uploadUri, Stream zipStream, string resources)
        {
            string boundary = DateTime.Now.Ticks.ToString("x");

            using (SimpleHttpClient httpClient = new SimpleHttpClient(this.Client.CancellationToken, AppsEndpoint.DefaultUploadTimeout))
            {
                httpClient.HttpProxy = Client.HttpProxy;
                httpClient.SkipCertificateValidation = Client.SkipCertificateValidation;

                httpClient.Headers.Add("Authorization", string.Format("bearer {0}", this.Client.AuthorizationToken));

                httpClient.Uri = uploadUri;
                httpClient.Method = HttpMethod.Post;

                List<HttpMultipartFormData> mpd = new List<HttpMultipartFormData>();
                using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(resources)))
                {
                    ms.Position = 0;
                    mpd.Add(new HttpMultipartFormData("resources", string.Empty, string.Empty, ms));
                    mpd.Add(new HttpMultipartFormData("application", "app.zip", "application/zip", zipStream));
                    SimpleHttpResponse response = await httpClient.SendAsync(mpd);
                    return response;
                }
            }
        }

        /// <summary>
        /// Filters the files that already exist on the server.
        /// </summary>
        /// <param name="fingerprints">The key of the dictionary is an SHA1 fingerprint</param>
        /// <returns>A list of files that do not exist on the server.</returns>
        private async Task<string[]> FilterExistingFiles(Dictionary<string, List<FileFingerprint>> fingerprints)
        {
            Dictionary<string, List<FileFingerprint>> filteredResources = new Dictionary<string, List<FileFingerprint>>();

            List<ListAllMatchingResourcesRequest> matchRequest = new List<ListAllMatchingResourcesRequest>();

            // Loop through each fingerprint and construct our request
            foreach (KeyValuePair<string, List<FileFingerprint>> fingerprintList in fingerprints)
            {
                foreach (FileFingerprint fingerprint in fingerprintList.Value)
                {
                    ListAllMatchingResourcesRequest match = new ListAllMatchingResourcesRequest()
                    {
                        Sha1 = fingerprint.SHA1,
                        Size = fingerprint.Size
                    };

                    matchRequest.Add(match);
                }

                // We're building the response with all fingerprints,
                // matches will be removed after the server replies
                filteredResources.Add(fingerprintList.Key, fingerprintList.Value);
            }

            ListAllMatchingResourcesResponse[] response = await this.Client.ResourceMatch.ListAllMatchingResources(matchRequest.ToArray());

            // If the request was cancelled, return immediately
            if (this.CheckCancellation())
            {
                return filteredResources.Values.SelectMany(list => list.Select(f => f.FileName)).ToArray();
            }

            // Remove all server matches from our result
            foreach (ListAllMatchingResourcesResponse resource in response)
            {
                filteredResources.Remove(resource.Sha1);
            }

            return filteredResources.Values.SelectMany(list => list.Select(f => f.FileName)).ToArray();
        }
    }
}