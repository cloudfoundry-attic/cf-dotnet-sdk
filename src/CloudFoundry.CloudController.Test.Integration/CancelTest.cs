using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using CloudFoundry.CloudController.V2.Client.Data;

namespace CloudFoundry.CloudController.Test.Integration
{
    [TestClass]
    public class CancelTest
    {
        [TestMethod]
        public void CancellationToken_test()
        {
            var cancelToken = new CancellationTokenSource();

            var client = TestUtil.GetClient(cancelToken.Token);

            try
            {
                var task = client.Info.GetInfo();
                cancelToken.Cancel();
                task.Wait();
                Assert.Fail("Expected OperationCanceledException but no exception was thrown");

            }
            catch (AggregateException aex)
            {
                foreach (var ex in aex.Flatten().InnerExceptions)
                {
                    if (!(ex is OperationCanceledException))
                    {
                        Assert.Fail(string.Format("Expected OperationCanceledException but got {0}", ex.ToString()));
                    }
                }
            }

        }

        [TestMethod]
        public void CancellationTokenMultipleRequests_test()
        {
            var cancelToken = new CancellationTokenSource();

            var client = TestUtil.GetClient(cancelToken.Token);
            Task[] tasks = new Task[4];
            try
            {
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = client.Info.GetInfo();
                }

                cancelToken.Cancel();
                Task.WaitAll(tasks);
                Assert.Fail("Expected OperationCanceledException but no exception was thrown");

            }
            catch (AggregateException aex)
            {
                foreach (var ex in aex.Flatten().InnerExceptions)
                {
                    if (!(ex is OperationCanceledException))
                    {
                        Assert.Fail(string.Format("Expected OperationCanceledException but got {0}", ex.ToString()));
                    }
                }
            }
        }

        [TestMethod]
        public void CancellationTokenMultipleRequestsCancel_test()
        {
            var cancelToken = new CancellationTokenSource();

            var client = TestUtil.GetClient(cancelToken.Token);

            Task<GetInfoResponse>[] tasks = new Task<GetInfoResponse>[4];
            GetInfoResponse response = null;

            try
            {
                for (int i = 0; i < tasks.Length; i++)
                {
                    tasks[i] = client.Info.GetInfo();
                    if (i == 0)
                    {
                        response = tasks[0].Result;
                        cancelToken.Cancel();
                    }
                }
                Assert.IsNotNull(response);
                Task.WaitAll(tasks);
                Assert.Fail("Expected OperationCanceledException but no exception was thrown");

            }
            catch (AggregateException aex)
            {
                foreach (var ex in aex.Flatten().InnerExceptions)
                {
                    if (!(ex is OperationCanceledException))
                    {
                        Assert.Fail(string.Format("Expected OperationCanceledException but got {0}", ex.ToString()));
                    }
                }
            }
        }
    }
}
