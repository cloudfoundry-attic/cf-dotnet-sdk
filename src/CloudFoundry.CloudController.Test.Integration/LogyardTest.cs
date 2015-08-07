using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using System.Threading;
using CloudFoundry.UAA;
using System.IO;
using CloudFoundry.Logyard.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class LogyardTest
    {
        private static string tempAppPath = Path.Combine(System.IO.Path.GetTempPath(), Path.GetRandomFileName());
        private static CloudFoundryClient client;
        private static CreateAppRequest apprequest;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            Directory.CreateDirectory(tempAppPath);

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
                Assert.Fail("Error while logging in" + ex.ToString());
            }

            PagedResponseCollection<ListAllSpacesResponse> spaces = client.Spaces.ListAllSpaces().Result;

            Guid spaceGuid = Guid.Empty;

            foreach (ListAllSpacesResponse space in spaces)
            {
                spaceGuid = space.EntityMetadata.Guid;
                break;
            }

            if (spaceGuid == Guid.Empty)
            {
                throw new Exception("No spaces found");
            }

            PagedResponseCollection<ListAllAppsResponse> apps = client.Apps.ListAllApps().Result;

            foreach (ListAllAppsResponse app in apps)
            {
                if (app.Name.StartsWith("logTest"))
                {
                    client.Apps.DeleteApp(app.EntityMetadata.Guid).Wait();
                    break;
                }
            }

            apprequest = new CreateAppRequest();
            apprequest.Name = "logTest" + Guid.NewGuid().ToString();
            apprequest.Memory = 64;
            apprequest.Instances = 1;
            apprequest.SpaceGuid = spaceGuid;
            apprequest.Buildpack = "https://github.com/ryandotsmith/null-buildpack.git";
            apprequest.EnvironmentJson = new Dictionary<string, string>() { { "env-test-1234", "env-test-value-1234" } };
            apprequest.Command = "export; cat content.txt; sleep 5000;";

            client.Apps.PushProgress += Apps_PushProgress;

            File.WriteAllText(Path.Combine(tempAppPath, "content.txt"), "dummy content");
        }

        static void Apps_PushProgress(object sender, PushProgressEventArgs e)
        {
            Console.WriteLine(e.Message + " " + e.Percent);
        }

        [TestMethod]
        public void LogyardRecentTest()
        {
            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;
            
            Guid appGuid = app.EntityMetadata.Guid;

            client.Apps.Push(appGuid, tempAppPath, true).Wait();

            while (true)
            {
                var appSummary = client.Apps.GetAppSummary(appGuid).Result;
                var packageState = appSummary.PackageState.ToLowerInvariant();

                if (packageState != "pending")
                {
                    Assert.AreEqual(packageState, "staged");

                    var instances = client.Apps.GetInstanceInformationForStartedApp(appGuid).Result;

                    if (instances.Count > 0)
                    {
                        if (instances[0].State.ToLower() == "running")
                        {
                            break;
                        }
                    }
                }
            }

            if (client.Info.GetV1Info().Result.AppLogEndpoint == null)
            {
                Assert.Inconclusive("CloudFoundry target does not have a logyard endpoint");
            }

            var logyardClient = new LogyardLog(
                new Uri(client.Info.GetV1Info().Result.AppLogEndpoint),
                string.Format("bearer {0}", client.AuthorizationToken),
                null,
                true);

            var logs = new List<string>();

            logyardClient.MessageReceived += delegate(object sender, MessageEventArgs e)
            {
                Assert.IsTrue(string.IsNullOrEmpty(e.Message.Error));
                logs.Add(e.Message.Value.Text);
            };


            logyardClient.ErrorReceived += delegate(object sender, Logyard.Client.ErrorEventArgs e)
            {
                Assert.Fail("Logyard error: {0}", e.Error.ToString());
            };

            var stopevent = new EventWaitHandle(false, EventResetMode.ManualReset);
            logyardClient.StreamClosed += delegate { stopevent.Set(); };

            // Just wait a bit to get the latest logs
            Thread.Sleep(1000);

            logyardClient.StartLogStream(appGuid.ToString(), 100, false);

            stopevent.WaitOne();

            var conatainsPushedContent = logs.Any((line) => line.Contains("dummy content"));
            Assert.IsTrue(conatainsPushedContent, "Pushed content was not dumped in the output stream: {0}", string.Join(Environment.NewLine, logs));

            var conatainsEnvContent = logs.Any((line) => line.Contains("env-test-1234"));
            Assert.IsTrue(conatainsEnvContent, "Pushed env variable was not dumped in the output stream: {0}", string.Join(Environment.NewLine, logs));

            client.Apps.DeleteApp(appGuid).Wait();
            Directory.Delete(tempAppPath, true);
        }
    }
}