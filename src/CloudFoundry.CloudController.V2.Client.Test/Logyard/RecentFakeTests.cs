using CloudFoundry.Logyard.Client;
using CloudFoundry.Logyard.Client.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace CloudFoundry.CloudController.V2.Client.Test.Logyard.FakeTest
{
    [TestClass]
    public class RecentFakeTests
    {
        Uri logyardEndpoint = new Uri("wss://logyard.xip.io:4443");

        [TestMethod, TestCategory("Fakes")]
        public void RecentWebSocketOpen()
        {
            using (ShimsContext.Create())
            {
                var openEvent = default(EventHandler<EventArgs>);
                var state = ConnectionState.None;
                var openEventFired = new ManualResetEvent(false);

                ShimLogyardWebSocket.AllInstances.StreamOpenedAddEventHandlerOfEventArgs = (@this, h) => openEvent = h;
                ShimLogyardWebSocket.AllInstances.StateGet = (@this) => { return state; };
                ShimLogyardWebSocket.AllInstances.OpenUriStringUriBoolean = (@this, appLogEndpoint, authenticationToken, proxy, skipCertValidation) => { state = ConnectionState.Open; };

                LogyardLog log = new LogyardLog(logyardEndpoint, string.Empty);
                log.StreamOpened += delegate(object sender, EventArgs e)
                {
                    openEventFired.Set();
                };

                log.StartLogStream(Guid.NewGuid().ToString(), 50);
                openEvent(this, EventArgs.Empty);

                Assert.IsTrue(openEventFired.WaitOne(100));
                Assert.AreEqual(log.State, ConnectionState.Open);
            }
        }


        [TestMethod, TestCategory("Fakes")]
        public void RecentWebSocketMessage()
        {
            using (ShimsContext.Create())
            {
                var openEvent = default(EventHandler<EventArgs>);
                var messageEvent = default(EventHandler<StringEventArgs>);
                var messageEventFired = new ManualResetEvent(false);

                Guid appGuid = Guid.NewGuid();
                string text = "This is a log entry";
                string source = "app";

                string json = string.Format(@"{{""value"":{{""source"":""{0}"", ""app_guid"":""{1}"", ""text"":""{2}"", ""syslog"":{{ }} }} }}", source, appGuid.ToString(), text);

                Message msg = new Message();
                msg.Value = new MessageValue();
                msg.Value.AppGuid = appGuid;
                msg.Value.Text = text;
                msg.Value.Source = source;
                msg.Value.Syslog = new ValueSyslog();

                ShimLogyardWebSocket.AllInstances.StreamOpenedAddEventHandlerOfEventArgs = (@this, h) => openEvent = h;
                ShimLogyardWebSocket.AllInstances.DataReceivedAddEventHandlerOfStringEventArgs = (@this, h) => messageEvent = h;
                ShimLogyardWebSocket.AllInstances.OpenUriStringUriBoolean = (@this, appLogEndpoint, authenticationToken, proxy, skipCertValidation) => { };

                LogyardLog log = new LogyardLog(logyardEndpoint, string.Empty);
                log.MessageReceived += delegate(object sender, MessageEventArgs e)
                {
                    Assert.AreEqual(msg.Value.Source, e.Message.Value.Source);
                    Assert.AreEqual(msg.Value.AppGuid, e.Message.Value.AppGuid);
                    Assert.AreEqual(msg.Value.Text, e.Message.Value.Text);
                    messageEventFired.Set();
                };

                log.StartLogStream(msg.Value.AppGuid.ToString());

                messageEvent(this, new StringEventArgs() { Data = json });
                Assert.IsTrue(messageEventFired.WaitOne(100));
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void RecentWebSockerError()
        {
            using (ShimsContext.Create())
            {
                var errorEvent = default(EventHandler<ErrorEventArgs>);
                var errorEventFired = new ManualResetEvent(false);

                ShimLogyardWebSocket.AllInstances.ErrorReceivedAddEventHandlerOfErrorEventArgs = (@this, h) => errorEvent = h;
                ShimLogyardWebSocket.AllInstances.OpenUriStringUriBoolean = (@this, appLogEndpoint, authenticationToken, proxy, skipCertValidation) => { };

                LogyardLog logyard = new LogyardLog(logyardEndpoint, string.Empty);
                logyard.ErrorReceived += delegate(object sender, ErrorEventArgs e)
                {
                    Assert.AreEqual("Test error", e.Error.Message);
                    errorEventFired.Set();
                };

                logyard.StartLogStream(Guid.NewGuid().ToString());

                errorEvent(this, new ErrorEventArgs() { Error = new LogyardException("Test error") });

                Assert.IsTrue(errorEventFired.WaitOne(100));
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void RecentWebSocketClosedTest()
        {
            using (ShimsContext.Create())
            {
                var closedEvent = default(EventHandler<EventArgs>);
                var closedEventFired = new ManualResetEvent(false);

                ShimLogyardWebSocket.AllInstances.StreamClosedAddEventHandlerOfEventArgs = (@this, h) => closedEvent = h;
                ShimLogyardWebSocket.AllInstances.OpenUriStringUriBoolean = (@this, appLogEndpoint, authenticationToken, proxy, skipCertValidation) => { };

                LogyardLog logyard = new LogyardLog(logyardEndpoint, string.Empty);
                logyard.StreamClosed += delegate(object sender, EventArgs e)
                {
                    closedEventFired.Set();
                };

                logyard.StartLogStream(Guid.NewGuid().ToString());
                closedEvent(this, EventArgs.Empty);

                Assert.IsTrue(closedEventFired.WaitOne(100));
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void StopRecentTest()
        {
            using (ShimsContext.Create())
            {
                var closedEvent = default(EventHandler<EventArgs>);
                var closedEventFired = new ManualResetEvent(false);

                ShimLogyardWebSocket.AllInstances.StreamClosedAddEventHandlerOfEventArgs = (@this, h) => closedEvent = h;
                ShimLogyardWebSocket.AllInstances.OpenUriStringUriBoolean = (@this, appLogEndpoint, authenticationToken, proxy, skipCertValidation) => { };
                ShimLogyardWebSocket.AllInstances.Close = (@this) =>
                {
                    closedEvent(this, EventArgs.Empty);
                };
                ShimLogyardWebSocket.AllInstances.Dispose = (@this) => { };

                LogyardLog logyard = new LogyardLog(logyardEndpoint, string.Empty);
                logyard.StreamClosed += delegate(object sender, EventArgs e)
                {
                    closedEventFired.Set();
                };

                logyard.StartLogStream(Guid.NewGuid().ToString(), 50, false);
                logyard.StopLogStream();

                Assert.IsTrue(closedEventFired.WaitOne(100));
                Assert.AreEqual(ConnectionState.None, logyard.State);
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void RecentNullAppIdTest()
        {
            using (ShimsContext.Create())
            {
                ShimLogyardWebSocket.AllInstances.OpenUriStringUriBoolean = (@this, appLogEndpoint, authenticationToken, proxy, skipCertValidation) => { };

                LogyardLog logyard = new LogyardLog(logyardEndpoint, string.Empty);

                try
                {
                    logyard.StartLogStream(null);
                }
                catch (Exception ex)
                {
                    Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                }
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void RecentTwiceTest()
        {
            using (ShimsContext.Create())
            {
                ShimLogyardWebSocket.AllInstances.OpenUriStringUriBoolean = (@this, appLogEndpoint, authenticationToken, proxy, skipCertValidation) => { };

                LogyardLog logyard = new LogyardLog(logyardEndpoint, string.Empty);

                string appGuid = Guid.NewGuid().ToString();
                logyard.StartLogStream(appGuid);
                try
                {
                    logyard.StartLogStream(appGuid);
                }
                catch (Exception ex)
                {
                    Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                    Assert.IsTrue(ex.Message.Contains("The log stream has already been started."));
                }
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void RecentWebSocketErrorMessage()
        {
            using (ShimsContext.Create())
            {
                var openEvent = default(EventHandler<EventArgs>);
                var messageEvent = default(EventHandler<StringEventArgs>);
                var messageEventFired = new ManualResetEvent(false);

                Guid appGuid = Guid.NewGuid();
                string error = "This is a error";                

                string json = string.Format(@"{{""error"":""{0}""}}", error);

                Message msg = new Message();
                msg.Error = error;

                ShimLogyardWebSocket.AllInstances.StreamOpenedAddEventHandlerOfEventArgs = (@this, h) => openEvent = h;
                ShimLogyardWebSocket.AllInstances.DataReceivedAddEventHandlerOfStringEventArgs = (@this, h) => messageEvent = h;
                ShimLogyardWebSocket.AllInstances.OpenUriStringUriBoolean = (@this, appLogEndpoint, authenticationToken, proxy, skipCertValidation) => { };

                LogyardLog log = new LogyardLog(logyardEndpoint, string.Empty);
                log.ErrorReceived += delegate(object sender, ErrorEventArgs e)
                {
                    Assert.AreEqual(msg.Error, e.Error.Message);
                    messageEventFired.Set();
                };

                log.StartLogStream(appGuid.ToString());

                messageEvent(this, new StringEventArgs() { Data = json });
                Assert.IsTrue(messageEventFired.WaitOne(100));
            }
        }
    }
}
