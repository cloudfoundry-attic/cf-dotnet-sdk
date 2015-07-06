using Microsoft.QualityTools.Testing.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thinktecture.IdentityModel.Client;

namespace CloudFoundry.CloudController.V3.Client.Test
{
    internal class MockClients
    {
        CloudFoundryClient cfClient;

        internal string JsonResponse = "";
        internal HttpStatusCode ExpectedStatusCode = HttpStatusCode.OK;


        Func<HttpResponseMessage> customMessageFunc = null;

        internal Func<HttpResponseMessage> CustomMessageFunc
        {
            set { customMessageFunc = value; }
        }

        internal CloudFoundryClient CreateCloudFoundryClient()
        {
            return CreateCloudFoundryClient(new CancellationToken());
        }

        internal CloudFoundryClient CreateCloudFoundryClient(CancellationToken cancellationToken)
        {
            System.Net.Http.Fakes.ShimHttpClient.AllInstances.SendAsyncHttpRequestMessageHttpCompletionOptionCancellationToken = sendHttpAsync;
            this.cfClient = new CloudFoundryClient(new Uri("http://127.0.0.1.co"), cancellationToken);

            return cfClient;
        }

        private Task<HttpResponseMessage> sendHttpAsync(HttpClient client, HttpRequestMessage message, HttpCompletionOption completionOption, CancellationToken cancelationToken)
        {
            if (customMessageFunc == null)
            {
                customMessageFunc = buildHttpResponseMessage;
            }
            var task = Task.Run(customMessageFunc);
            return task;
        }

        private HttpResponseMessage buildHttpResponseMessage()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage.Content = new StringContent(this.JsonResponse);
            responseMessage.StatusCode = ExpectedStatusCode;
            return responseMessage;
        }


    }
}
