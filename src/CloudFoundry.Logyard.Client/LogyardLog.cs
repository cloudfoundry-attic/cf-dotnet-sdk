using CloudFoundry.CloudController.V2.Exceptions;
using System;
using System.Collections.Generic;
using WebSocket4Net;

namespace CloudFoundry.Logyard.Client
{
    public delegate void MessageReceivedEventHandler(object sender, Message message);

    public delegate void ErrorReceivedEventHandler(object sender, Exception e);

    public delegate void StreamOpenedEventHandler(object sender, EventArgs e);

    public delegate void StreamClosedEventHandler(object sender, EventArgs e);

    public class LogyardLog
    {
        public event MessageReceivedEventHandler MessageReceived;

        public event ErrorReceivedEventHandler ErrorReceived;

        public event StreamClosedEventHandler StreamOpened;

        public event StreamClosedEventHandler StreamClosed;

        public string AuthorizationToken { get; set; }

        private string endpoint;
        private WebSocket ws;

        public ConnectionState State
        {
            get
            {
                if (this.ws != null)
                {
                    switch (ws.State)
                    {
                        case WebSocketState.Closed:
                            {
                                return ConnectionState.Closed;
                            }
                        case WebSocketState.Closing:
                            {
                                return ConnectionState.Closing;
                            }
                        case WebSocketState.Connecting:
                            {
                                return ConnectionState.Connecting;
                            }
                        case WebSocketState.Open:
                            {
                                return ConnectionState.Open;
                            }
                        default:
                            {
                                return ConnectionState.None;
                            }
                    }
                }
                else
                    return ConnectionState.None;
            }
        }

        private LogyardLog(string loggingEndpoint) 
        {
            this.endpoint = loggingEndpoint;
        }

        public static LogyardLog GetLogyardLog(string apiEndpoint, bool ignoreCertificate = false)
        {
            if (ignoreCertificate)
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            }

            CloudFoundry.CloudController.V2.CloudFoundryClient client = new CloudController.V2.CloudFoundryClient(new Uri(apiEndpoint), new System.Threading.CancellationToken());
            var info = client.Info.GetV1Info().Result;

            return new LogyardLog(info.AppLogEndpoint);
        }

        public void StreamLogs(string appGuid, int num = 0, bool tail = false)
        {
            string applogEndpoint = string.Format("{0}/v2/apps/{1}", this.endpoint, appGuid.ToString());
            if (tail)
            {
                applogEndpoint += "/tail";
            }
            else
            {
                applogEndpoint += "/recent";
            }

            if (num != 0)
            {
                applogEndpoint += string.Format("?num={0}", num.ToString());
            }

            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>>();
            if (this.AuthorizationToken != null)
            {
                headers.Add(new KeyValuePair<string, string>("AUTHORIZATION", this.AuthorizationToken));
            }
            this.ws = new WebSocket(applogEndpoint, "", null, headers);

            this.ws.MessageReceived += ws_MessageReceived;
            this.ws.Error += ws_Error;
            this.ws.Opened += ws_Opened;
            this.ws.Closed += ws_Closed;
            this.ws.ReceiveBufferSize = 64;
            this.ws.Open();            
        }

        public void Stop()
        {
            if(this.ws.State != (WebSocketState.Closed | WebSocketState.Closing | WebSocketState.None))
            {
                this.ws.Close();
            }
        }

        private void ws_Closed(object sender, EventArgs e)
        {
            if (this.StreamClosed != null)
            {
                StreamClosed(this, e);
            }
        }

        private void ws_Opened(object sender, EventArgs e)
        {
            if (this.StreamOpened != null)
            {
                StreamOpened(this, e);
            }
        }

        private void ws_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            if (this.ErrorReceived != null)
            {
                ErrorReceived(this, e.Exception);
            }
        }

        private void ws_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Message ms = JsonUtilities.DeserializaeLogyardMessage(e.Message);
            if (ms.Error != string.Empty)
            {
                if (ms.Error.Contains("CF-InvalidAuthToken"))
                {
                    if (ErrorReceived != null)
                        ErrorReceived(this, new AuthenticationException(ms.Error));
                }
                else
                {
                    if (ErrorReceived != null)
                        ErrorReceived(this, new Exception(ms.Error));
                }
            }
            else
            {
                if (MessageReceived != null)
                    MessageReceived(this, ms);
            }
        }
    }
}