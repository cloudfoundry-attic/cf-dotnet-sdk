using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using System.Threading;
using CloudFoundry.UAA;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class PushTest
    {
        private static string appPath = @"C:\test";
        private static CloudFoundryClient client;
        private static CreateAppRequest apprequest;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            client = TestUtil.GetClient();
            CloudCredentials credentials = new CloudCredentials();
            credentials.User = TestUtil.User;
            credentials.Password = TestUtil.Password;
            try
            {
                client.Login(credentials).Wait();
            }
            catch (Exception ex)
            {
                Assert.Fail("Error while loging in" + ex.ToString());
            }

            PagedResponseCollection<ListAllSpacesResponse> spaces = client.Spaces.ListAllSpaces().Result;

            var spaceGuid = string.Empty;

            foreach (ListAllSpacesResponse space in spaces)
            {
                spaceGuid = space.EntityMetadata.Guid;
                break;
            }

            if (spaceGuid == string.Empty)
            {
                throw new Exception("No spaces found");
            }

            PagedResponseCollection<ListAllStacksResponse> stacks = client.Stacks.ListAllStacks().Result;

            var winStack = string.Empty;

            foreach (ListAllStacksResponse stack in stacks)
            {
                if (stack.Name == "win2012")
                {
                    winStack = stack.EntityMetadata.Guid;
                    break;
                }
            }

            if (winStack == string.Empty)
            {
                throw new Exception("Could not test on a deployment without a windows 2012 stack");
            }

            PagedResponseCollection<ListAllAppsResponse> apps = client.Apps.ListAllApps().Result;

            foreach (ListAllAppsResponse app in apps)
            {
                if (app.Name == "simplePushTest")
                {
                    client.Apps.DeleteApp(new Guid(app.EntityMetadata.Guid)).Wait();
                    break;
                }
            }

            apprequest = new CreateAppRequest();
            apprequest.Name = "simplePushTest";
            apprequest.Memory = 512;
            apprequest.Instances = 1;
            apprequest.SpaceGuid = new Guid(spaceGuid);
            apprequest.StackGuid = new Guid(winStack);

            client.Apps.PushProgress += Apps_PushProgress;
        }

        static void Apps_PushProgress(object sender, PushProgressEventArgs e)
        {
            Console.WriteLine(e.Message + " " + e.Percent);
        }

        [TestMethod]
        public void PushJobTest()
        {
            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;

            Guid appGuid = new Guid(app.EntityMetadata.Guid);

            client.Apps.Push(appGuid, appPath, true).Wait();

            client.Apps.DeleteApp(appGuid).Wait();
        }

        [TestMethod]
        public void DoublePush()
        {
            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;

            client.Apps.Push(new Guid(app.EntityMetadata.Guid), appPath, false).Wait();

            UpdateAppRequest updateApp=new UpdateAppRequest();
            updateApp.Name = app.Name;
            updateApp.Memory = 512;
            updateApp.Instances = 1;
            
            UpdateAppResponse updatedApp = client.Apps.UpdateApp(new Guid(app.EntityMetadata.Guid), updateApp).Result;

            client.Apps.Push(new Guid(app.EntityMetadata.Guid), appPath, false).Wait();

            client.Apps.DeleteApp(new Guid(app.EntityMetadata.Guid)).Wait();
        }

    }
}