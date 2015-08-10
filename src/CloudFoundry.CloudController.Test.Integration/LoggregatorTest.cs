using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Client.Data;
using System.Threading;
using CloudFoundry.UAA;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudFoundry.Loggregator.Client;


namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class LoggregatorTest
    {
        private string tempAppPath = Path.Combine(System.IO.Path.GetTempPath(), Path.GetRandomFileName());
        private CloudFoundryClient client;
        private CreateAppRequest apprequest;

        [TestInitialize]
        public void TestInit()
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
            apprequest.EnvironmentJson = new Dictionary<string, string>() { { "envtest1234", "envtestvalue1234" } };
            apprequest.Command = "printenv; cat content.txt; ping 127.0.0.1;";

            client.Apps.PushProgress += Apps_PushProgress;

            File.WriteAllText(Path.Combine(tempAppPath, "content.txt"), "dummy content");
        }

        static void Apps_PushProgress(object sender, PushProgressEventArgs e)
        {
            Console.WriteLine(e.Message + " " + e.Percent);
        }

        [TestMethod]
        [TestCategory("RequiresLoggregator")]
        public void LoggregatorRecentTest()
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

            if (client.Info.GetInfo().Result.LoggingEndpoint == null)
            {
                Assert.Inconclusive("CloudFoundry target does not have a loggregator endpoint");
            }

            var logClient = new LoggregatorLog(
                new Uri(client.Info.GetInfo().Result.LoggingEndpoint),
                string.Format("bearer {0}", client.AuthorizationToken),
                null,
                true);

            // Just wait a bit to get the latest logs
            Thread.Sleep(1000);

            var appLogs = logClient.Recent(appGuid.ToString(), CancellationToken.None).Result;

            var conatainsPushedContent = appLogs.Any((line) => line.Message.Contains("dummy content"));
            Assert.IsTrue(conatainsPushedContent, "Pushed content was not dumped in the output stream: {0}", string.Join(Environment.NewLine, appLogs.Select(x => x.Message)));

            var conatainsEnvContent = appLogs.Any((line) => line.Message.Contains("envtest1234"));
            Assert.IsTrue(conatainsEnvContent, "Pushed env variable was not dumped in the output stream: {0}", string.Join(Environment.NewLine, appLogs.Select(x => x.Message)));

            client.Apps.DeleteApp(appGuid).Wait();
            Directory.Delete(tempAppPath, true);
        }

        [TestMethod]
        [TestCategory("RequiresLoggregator")]
        public void LoggregatorTailTest()
        {
            CreateAppResponse app = client.Apps.CreateApp(apprequest).Result;

            Guid appGuid = app.EntityMetadata.Guid;

            if (client.Info.GetInfo().Result.LoggingEndpoint == null)
            {
                Assert.Inconclusive("CloudFoundry target does not have a loggregator endpoint");
            }

            var logClient = new LoggregatorLog(
                new Uri(client.Info.GetInfo().Result.LoggingEndpoint),
                string.Format("bearer {0}", client.AuthorizationToken),
                null,
                true);

            var logs = new List<string>();

            logClient.MessageReceived += delegate(object sender, MessageEventArgs e)
            {
                long timeInMilliSeconds = e.LogMessage.Timestamp / 1000 / 1000;
                var logTimeStamp = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(timeInMilliSeconds);

                logs.Add(String.Format("[{0}] - {1}: {2}", e.LogMessage.SourceName, logTimeStamp.ToString(), e.LogMessage.Message));
            };


            logClient.ErrorReceived += delegate(object sender, CloudFoundry.Loggregator.Client.ErrorEventArgs e)
            {
                Assert.Fail("Loggregator error: {0}", e.Error.ToString());
            };

            logClient.Tail(appGuid.ToString());

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

            // Just wait a bit to get the latest logs
            Thread.Sleep(1000);

            logClient.StopLogStream();

            var conatainsPushedContent = logs.Any((line) => line.Contains("dummy content"));
            Assert.IsTrue(conatainsPushedContent, "Pushed content was not dumped in the output stream: {0}", string.Join(Environment.NewLine, logs));

            var conatainsEnvContent = logs.Any((line) => line.Contains("envtest1234"));
            Assert.IsTrue(conatainsEnvContent, "Pushed env variable was not dumped in the output stream: {0}", string.Join(Environment.NewLine, logs));

            client.Apps.DeleteApp(appGuid).Wait();
            Directory.Delete(tempAppPath, true);
        }
    }
}