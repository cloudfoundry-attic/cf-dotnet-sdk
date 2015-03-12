using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CloudFoundry.Loggregator.Client.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using System.Threading;

namespace CloudFoundry.Loggregator.Client.Test.FakeTest
{
    [TestClass]
    public class TailFakeTests
    {
        Uri loggregatorEndpoint = new Uri("wss://loggregator.xip.io:4443");

        [TestMethod, TestCategory("Fakes")]
        public void TailWebSocketOpen()
        {
            using (ShimsContext.Create())
            {
                var openEvent = default(EventHandler<EventArgs>);
                var state = ConnectionState.None;
                var openEventFired = new ManualResetEvent(false);

                ShimLoggregatorWebSocket.AllInstances.StreamOpenedAddEventHandlerOfEventArgs = (@this, h) => openEvent = h;
                ShimLoggregatorWebSocket.AllInstances.StateGet = (@this) => { return state; };
                ShimLoggregatorWebSocket.AllInstances.OpenUriString = (@this, appLogEndpoint, authenticationToken) => { state = ConnectionState.Open; };

                LoggregatorLog loggregator = new LoggregatorLog(loggregatorEndpoint, string.Empty);
                loggregator.StreamOpened += delegate(object sender, EventArgs e)
                {
                    openEventFired.Set();
                };

                loggregator.Tail(Guid.NewGuid().ToString());
                openEvent(this, EventArgs.Empty);

                Assert.IsTrue(openEventFired.WaitOne(100));
                Assert.AreEqual(loggregator.State, ConnectionState.Open);
            }
        }


        [TestMethod, TestCategory("Fakes")]
        public void TailWebSocketMessage()
        {
            using(ShimsContext.Create())
            {                
                var openEvent = default(EventHandler<EventArgs>);
                var messageEvent = default(EventHandler<DataEventArgs>);
                var messageEventFired = new ManualResetEvent(false);

                ApplicationLog msg = new ApplicationLog();
                msg.AppId = Guid.NewGuid().ToString();
                msg.Message = "This is a log entry";
                msg.LogMessageType = ApplicationLogMessageType.Output;                

                ShimLoggregatorWebSocket.AllInstances.StreamOpenedAddEventHandlerOfEventArgs = (@this, h) => openEvent = h;
                ShimLoggregatorWebSocket.AllInstances.DataReceivedAddEventHandlerOfDataEventArgs = (@this, h) => messageEvent = h;
                ShimLoggregatorWebSocket.AllInstances.OpenUriString = (@this, appLogEndpoint, authenticationToken) => { };

                LoggregatorLog loggregator = new LoggregatorLog(loggregatorEndpoint, string.Empty);
                loggregator.MessageReceived += delegate(object sender, MessageEventArgs e)
                {
                    Assert.AreEqual(msg, e.LogMessage);
                    messageEventFired.Set();
                };

                loggregator.Tail(msg.AppId);

                messageEvent(this, new DataEventArgs() { Data = msg });                
                Assert.IsTrue(messageEventFired.WaitOne(100));
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void TailWebSockerError()
        {
            using (ShimsContext.Create())
            {
                var errorEvent = default(EventHandler<ErrorEventArgs>);
                var errorEventFired = new ManualResetEvent(false);
                               
                ShimLoggregatorWebSocket.AllInstances.ErrorReceivedAddEventHandlerOfErrorEventArgs = (@this, h) => errorEvent = h;
                ShimLoggregatorWebSocket.AllInstances.OpenUriString = (@this, appLogEndpoint, authenticationToken) => { };

                LoggregatorLog loggregator = new LoggregatorLog(loggregatorEndpoint, string.Empty);
                loggregator.ErrorReceived += delegate(object sender, ErrorEventArgs e)
                {
                    Assert.AreEqual("Test error", e.Error.Message);
                    errorEventFired.Set();
                };

                loggregator.Tail(Guid.NewGuid().ToString());

                errorEvent(this, new ErrorEventArgs() { Error = new LoggregatorException("Test error") });
                
                Assert.IsTrue(errorEventFired.WaitOne(100));
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void TailWebSocketClosedTest()
        {
            using (ShimsContext.Create())
            {
                var closedEvent = default(EventHandler<EventArgs>);                
                var closedEventFired = new ManualResetEvent(false);

                ShimLoggregatorWebSocket.AllInstances.StreamClosedAddEventHandlerOfEventArgs = (@this, h) => closedEvent = h;
                ShimLoggregatorWebSocket.AllInstances.OpenUriString = (@this, appLogEndpoint, authenticationToken) => { };
                
                LoggregatorLog loggregator = new LoggregatorLog(loggregatorEndpoint, string.Empty);
                loggregator.StreamClosed += delegate(object sender, EventArgs e)
                {
                    closedEventFired.Set();
                };

                loggregator.Tail(Guid.NewGuid().ToString());
                closedEvent(this, EventArgs.Empty);

                Assert.IsTrue(closedEventFired.WaitOne(100));
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void StopTailTest()
        {
            using (ShimsContext.Create())
            {
                var closedEvent = default(EventHandler<EventArgs>);
                var closedEventFired = new ManualResetEvent(false);                
                
                ShimLoggregatorWebSocket.AllInstances.StreamClosedAddEventHandlerOfEventArgs = (@this, h) => closedEvent = h;
                ShimLoggregatorWebSocket.AllInstances.OpenUriString = (@this, appLogEndpoint, authenticationToken) => { };
                ShimLoggregatorWebSocket.AllInstances.Close = (@this) => {                    
                    closedEvent(this, EventArgs.Empty); 
                };
                ShimLoggregatorWebSocket.AllInstances.Dispose = (@this) => { };

                LoggregatorLog loggregator = new LoggregatorLog(loggregatorEndpoint, string.Empty);
                loggregator.StreamClosed += delegate(object sender, EventArgs e)
                {
                    closedEventFired.Set();
                };

                loggregator.Tail(Guid.NewGuid().ToString());
                loggregator.StopLogStream();

                Assert.IsTrue(closedEventFired.WaitOne(100));
                Assert.AreEqual(ConnectionState.None, loggregator.State);
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void TailNullAppIdTest()
        {
            using (ShimsContext.Create())
            {
                ShimLoggregatorWebSocket.AllInstances.OpenUriString = (@this, appLogEndpoint, authenticationToken) => { };

                LoggregatorLog loggregator = new LoggregatorLog(loggregatorEndpoint, string.Empty);

                try
                {
                    loggregator.Tail(null);
                }
                catch(Exception ex)
                {
                    Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                }                
            }
        }

        [TestMethod, TestCategory("Fakes")]
        public void TailTwiceTest()
        {
            using (ShimsContext.Create())
            {
                ShimLoggregatorWebSocket.AllInstances.OpenUriString = (@this, appLogEndpoint, authenticationToken) => { };

                LoggregatorLog loggregator = new LoggregatorLog(loggregatorEndpoint, string.Empty);

                string appGuid = Guid.NewGuid().ToString();
                loggregator.Tail(appGuid);
                try
                {
                    loggregator.Tail(appGuid);
                }
                catch (Exception ex)
                {
                    Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                    Assert.IsTrue(ex.Message.Contains("The log stream has already been started."));
                }
            }
        }
    }
}
