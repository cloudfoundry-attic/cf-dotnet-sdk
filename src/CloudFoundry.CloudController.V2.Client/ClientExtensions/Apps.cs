namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.V2.Client.Data;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
using System.IO;
    using CloudFoundry.CloudController.Common.Http;
    using System.Net.Http;

    public struct FileFingerprint
    {
        public long Size
        {
            get;
            set;
        }

        public string Sha1
        {
            get;
            set;
        }

        public string Filename
        {
            get;
            set;
        }
    }

    public interface IAppPushTools
    {
        Task<Dictionary<string, FileFingerprint>> GetFileFingerprints(string appPath, CancellationToken cancellationToken);
        Task<Stream> GetZippedPayload(List<string> files, CancellationToken cancellationToken);
    }

    public partial class AppsEndpoint
    {
        private const int StepCount = 5;
        public event EventHandler<PushProgressEventArgs> PushProgress;
        
        /// <summary>
        /// Pushes an application to the cloud.
        /// <remarks>
        /// This method is only available on the .NET 4.5 framework. 
        /// Calling this method from a Windows Phone App or a Windows App will throw a <see cref="NotImplementedException"/>.
        /// </remarks>
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        /// <param name="app">Basic information needed to create an app</param>
        /// <param name="appPath">Path of origin from which the application will be deployed</param>
        /// <param name="startApplication">True if the app should be started after upload is complete, false otherwise</param>
        public async Task<Guid?> Push<T>(CreateAppRequest app, string appPath, bool startApplication) where T : class, IAppPushTools, new()
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }

            if (appPath == null)
            {
                throw new ArgumentNullException("appPath");
            }

            IAppPushTools pushTools = new T();
            int usedSteps = 1;

            // Step 1 - Create an application in Cloud Foundry
            this.TriggerPushProgressEvent(usedSteps, "Creating application {0} ...", app.Name);
            CreateAppResponse createResult = await CreateApp(app);
            if (this.CheckCancellation())
            {
                return null;
            }
            usedSteps += 1;

            // Step 2 - Compute fingerprints for local files
            this.TriggerPushProgressEvent(usedSteps, "Calculating file fingerprints ...");
            Dictionary<string, FileFingerprint> fingerprints = await pushTools.GetFileFingerprints(appPath, this.Client.CancellationToken);
            if (this.CheckCancellation())
            {
                return null;
            }
            usedSteps += 1;

            // Step 3 - Compare fingerprints of local files with what the server has
            this.TriggerPushProgressEvent(usedSteps, "Comparing file fingerprints ...");
            List<string> neededFiles = await this.FilterExistingFiles(fingerprints);
            if (this.CheckCancellation())
            {
                return null;
            }
            usedSteps += 1;

            // Step 4 - Zip all needed files and get a stream back from the PushTools
            this.TriggerPushProgressEvent(usedSteps, "Creating zip package ...");
            using (Stream zippedPayload = await pushTools.GetZippedPayload(neededFiles, this.Client.CancellationToken))
            {
                if (this.CheckCancellation())
                {
                    return null;
                }
                usedSteps += 1;

                // Step 5 - Upload zip to CloudFoundry ...
                this.TriggerPushProgressEvent(usedSteps, "Uploading zip package ...");
                string route = string.Format(CultureInfo.InvariantCulture, "/v2/apps/{0}/bits", createResult.EntityMetadata.Guid);
                string endpoint = string.Format(CultureInfo.InvariantCulture, "{0}{1}", this.Client.CloudTarget.AbsoluteUri.ToString().TrimEnd('/'), route);
                string serializedFingerprints = GetFileFingerprintPayload(fingerprints);
                IHttpResponseAbstraction uploadResult = await this.UploadZip(new Uri(endpoint), zippedPayload, serializedFingerprints);
                if (this.CheckCancellation())
                {
                    return null;
                }
                usedSteps += 1;
            }

            if (startApplication)
            {
                // Step 6 - Start Application

                if (this.CheckCancellation())
                {
                    return null;
                }
                usedSteps += 1;
            }

            // Step 7 - Done
            this.TriggerPushProgressEvent(usedSteps, "Application {0} pushed successfully", app.Name);

            return new Guid(createResult.EntityMetadata.Guid);
        }

        private void TriggerPushProgressEvent(int progress, string message, params string[] formatParameters)
        {
            this.TriggerPushProgressEvent(progress, string.Format(CultureInfo.InvariantCulture, message, formatParameters));
        }

        private void TriggerPushProgressEvent(int currentStep, string message)
        {
            if (this.PushProgress != null)
            {
                this.PushProgress(this, new PushProgressEventArgs()
                {
                    Message = message,
                    Percent = (int)(((double)currentStep / (double)StepCount) * 100)
                });
            }
        }

        private bool CheckCancellation()
        {
            if (this.Client.CancellationToken.IsCancellationRequested)
            {
                this.TriggerPushProgressEvent(StepCount, "Push cancelled");
                return true;
            }

            return false;
        }

        private string GetFileFingerprintPayload(Dictionary<string, FileFingerprint> fingerprint)
        {

        }

        private async Task<IHttpResponseAbstraction> UploadZip(Uri uploadUri, Stream zipStream, string resources)
        {
            string boundary = DateTime.Now.Ticks.ToString("x");

            HttpAbstractionClientFactory fact = new HttpAbstractionClientFactory();

            using (var httpClient = fact.Create())
            {
                httpClient.Headers.Add("Authorization", string.Format("bearer {0}", this.Client.AuthorizationToken));

                httpClient.Uri = uploadUri;
                httpClient.Headers.Add("Accept", "*/*; q=0.5, application/xml");
                httpClient.Headers.Add("Accept-Encoding", "gzip, deflate");
                httpClient.Method = HttpMethod.Post;

                List<HttpMultipartFormDataAbstraction> mpd = new List<HttpMultipartFormDataAbstraction>();

                using (Stream fileStream = await fileInfo.OpenAsync(FileAccess.Read))
                {
                    mpd.Add(new HttpMultipartFormDataAbstraction("application", Path.GetFileName(file), "application/zip", fileStream));

                    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(resources)))
                    {
                        ms.Position = 0;
                        mpd.Add(new HttpMultipartFormDataAbstraction("resources", string.Empty, string.Empty, ms));
                        IHttpResponseAbstraction response = await httpClient.SendAsync(mpd);
                        return response;
                    }
                }
            }
        }

        /// <summary>
        /// Filters the files that already exist on the server.
        /// </summary>
        /// <param name="fingerprints">The key of the dictionary is an SHA1 fingerprint</param>
        /// <returns>A list of file names that do not exist on the server.</returns>
        private async Task<List<string>> FilterExistingFiles(Dictionary<string, FileFingerprint> fingerprints)
        {
            Dictionary<string, FileFingerprint> filteredResources = new Dictionary<string, FileFingerprint>();

            List<ListAllMatchingResourcesRequest> matchRequest = new List<ListAllMatchingResourcesRequest>();

            // Loop through each fingerprint and construct our request
            foreach (var fingerprint in fingerprints.Values)
            {
                ListAllMatchingResourcesRequest match = new ListAllMatchingResourcesRequest()
                {
                    Sha1 = fingerprint.Sha1,
                    Size = fingerprint.Size
                };

                matchRequest.Add(match);

                // We're building the response with all fingerprints,
                // matches will be removed after the server replies
                filteredResources[fingerprint.Sha1] = fingerprint;
            }

            ListAllMatchingResourcesResponse[] response = await this.Client.ResourceMatch.ListAllMatchingResources(matchRequest.ToArray());

            // If the request was cancelled, return immediately
            if (this.CheckCancellation())
            {
                return filteredResources.Values.Select(f => f.Filename).ToList();
            }

            // Remove all server matches from our result
            foreach (ListAllMatchingResourcesResponse resource in response)
            {
                filteredResources.Remove(resource.Sha1);
            }

            return filteredResources.Values.Select(f => f.Filename).ToList();
        }
    }
}