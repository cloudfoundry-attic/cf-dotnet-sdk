namespace CloudFoundry.CloudController.V3.Client
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common.Exceptions;
    using CloudFoundry.CloudController.Common.Http;
    using CloudFoundry.CloudController.Common.PushTools;
    using CloudFoundry.CloudController.V3.Client.Data;
    using Newtonsoft.Json;

    public partial class AppsExperimentalEndpoint
    {
        private const int StepCount = 8;

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
        /// <param name="stack">The name of the stack the app will be running on</param>
        /// <param name="buildpackGitUrl">Git URL of the buildpack</param>
        /// <param name="startApplication">True if the app should be started after upload is complete, false otherwise</param>
        /// <param name="diskLimit">Memory limit used to stage package</param>
        /// <param name="memoryLimit">Disk limit used to stage package</param>
        public async Task Push(Guid appGuid, string appPath, string stack, string buildpackGitUrl, bool startApplication, int memoryLimit, int diskLimit)
        {
            if (appPath == null)
            {
                throw new ArgumentNullException("appPath");
            }

            IAppPushTools pushTools = new AppPushTools(appPath);
            int usedSteps = 1;

            // Step 1 - Check if application exists
            this.TriggerPushProgressEvent(usedSteps, "Checking if application exists");
            GetAppResponse app = await this.Client.AppsExperimental.GetApp(appGuid);

            usedSteps += 1;

            // Step 2 - Create package
            CreatePackageRequest createPackage = new CreatePackageRequest();
            createPackage.Type = "bits";
            CreatePackageResponse packageResponse = await this.Client.PackagesExperimental.CreatePackage(appGuid, createPackage);

            Guid packageId = new Guid(packageResponse.Guid.ToString());

            if (this.CheckCancellation())
            {
                return;
            }

            usedSteps += 1;

            // Step 3 - Zip all needed files and get a stream back from the PushTools
            this.TriggerPushProgressEvent(usedSteps, "Creating zip package ...");
            using (Stream zippedPayload = await pushTools.GetZippedPayload(this.Client.CancellationToken))
            {
                if (this.CheckCancellation())
                {
                    return;
                }

                usedSteps += 1;

                // Step 4 - Upload zip to CloudFoundry ...
                this.TriggerPushProgressEvent(usedSteps, "Uploading zip package ...");

                await this.Client.PackagesExperimental.UploadBits(packageId, zippedPayload);

                bool uploadProcessed = false;
                while (!uploadProcessed)
                {
                    GetPackageResponse getPackage = await this.Client.PackagesExperimental.GetPackage(packageId);
                    switch (getPackage.State)
                    {
                        case "FAILED":
                            {
                                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Upload failed: {0}", getPackage.Data["error"]));
                            }

                        case "READY":
                            {
                                uploadProcessed = true;
                                break;
                            }

                        default: continue;
                    }

                    if (this.CheckCancellation())
                    {
                        return;
                    }

                    Task.Delay(500).Wait();
                }

                usedSteps += 1;
            }

            // Step 5 - Stage application
            StagePackageRequest stagePackage = new StagePackageRequest();
            stagePackage.Lifecycle = new Dictionary<string, dynamic>();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["buildpack"] = buildpackGitUrl;
            data["stack"] = stack;
            stagePackage.Lifecycle["data"] = data;
            stagePackage.Lifecycle["type"] = "buildpack";
            stagePackage.MemoryLimit = memoryLimit;
            stagePackage.DiskLimit = diskLimit;
            
            StagePackageResponse stageResponse = await this.Client.PackagesExperimental.StagePackage(packageId, stagePackage);
            if (this.CheckCancellation())
            {
                return;
            }

            usedSteps += 1;
            if (startApplication)
            {
                bool staged = false;
                while (!staged)
                {
                    GetDropletResponse getDroplet = await this.Client.DropletsExperimental.GetDroplet(new Guid(stageResponse.Guid.ToString()));
                    switch (getDroplet.State)
                    {
                        case "FAILED":
                            {
                                throw new Exception(string.Format(CultureInfo.InvariantCulture, "Staging failed: {0}", getDroplet.Error));
                            }

                        case "STAGED":
                            {
                                staged = true;
                                break;
                            }

                        default: continue;
                    }

                    if (this.CheckCancellation())
                    {
                        return;
                    }

                    Task.Delay(500).Wait();
                }

                // Step 6 - Assign droplet
                AssignDropletAsAppsCurrentDropletRequest assignRequest = new AssignDropletAsAppsCurrentDropletRequest();
                assignRequest.DropletGuid = stageResponse.Guid;
                AssignDropletAsAppsCurrentDropletResponse assignDroplet = await this.AssignDropletAsAppsCurrentDroplet(appGuid, assignRequest);
                if (this.CheckCancellation())
                {
                    return;
                }

                usedSteps += 1;

                // Step 7 - Start Application                
                StartingAppResponse response = await this.Client.AppsExperimental.StartingApp(appGuid);
                if (this.CheckCancellation())
                {
                    return;
                }

                usedSteps += 1;
            }

            // Step 8 - Done
            this.TriggerPushProgressEvent(usedSteps, "Application {0} pushed successfully", app.Name);
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
        /// Triggers the PushProgress event
        /// </summary>
        /// <param name="currentStep">Current progress step</param>
        /// <param name="message">Message describing push progress</param>
        /// <param name="formatParameters">Format parameters for the message</param>
        private void TriggerPushProgressEvent(int currentStep, string message, params string[] formatParameters)
        {
            this.TriggerPushProgressEvent(currentStep, string.Format(CultureInfo.InvariantCulture, message, formatParameters));
        }
    }
}