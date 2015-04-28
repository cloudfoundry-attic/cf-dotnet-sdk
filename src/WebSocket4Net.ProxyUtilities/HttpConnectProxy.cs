namespace WebSocket4Net.ProxyUtilities
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using SuperSocket.ClientEngine;

    // Source: https://github.com/kerryjiang/SuperSocket.ClientEngine/blob/42d5974a46e2f57815dd91cef759bd70a9acd475/Proxy/HttpConnectProxy.cs
    // With extra patch: http://stackoverflow.com/questions/23024121/how-to-use-proxies-with-the-websocket4net-library
    public class HttpConnectProxy : ProxyConnectorBase
    {
        private const string RequestTemplate = "CONNECT {0}:{1} HTTP/1.1\r\nHost: {0}:{1}\r\nProxy-Connection: Keep-Alive\r\n\r\n";

        private const string ResponsePrefix = "HTTP/1.1";

        private const char Space = ' ';

        private static byte[] lineSeparator = Encoding.ASCII.GetBytes("\r\n\r\n");

        private int receiveBufferSize;

        public HttpConnectProxy(EndPoint proxyEndPoint)
            : this(proxyEndPoint, 128)
        {
        }

        public HttpConnectProxy(EndPoint proxyEndPoint, int receiveBufferSize)
            : base(proxyEndPoint)
        {
            this.receiveBufferSize = receiveBufferSize;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Justification = "Keep similar style with upstream"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Keep similar style with upstream")]
        public override void Connect(EndPoint remoteEndPoint)
        {
            if (remoteEndPoint == null)
            {
                throw new ArgumentNullException("remoteEndPoint");
            }

            if (!(remoteEndPoint is IPEndPoint || remoteEndPoint is DnsEndPoint))
            {
                throw new ArgumentException("remoteEndPoint must be IPEndPoint or DnsEndPoint", "remoteEndPoint");
            }

            try
            {
                ProxyEndPoint.ConnectAsync(this.ProcessConnect, remoteEndPoint);
            }
            catch (Exception e)
            {
                this.OnException(new Exception("Failed to connect proxy server", e));
            }
        }

        protected override void ProcessConnect(Socket socket, object targetEndPoint, SocketAsyncEventArgs e)
        {
            if (e != null)
            {
                if (!this.ValidateAsyncResult(e))
                {
                    return;
                }
            }

            if (socket == null)
            {
                this.OnException(new SocketException((int)SocketError.ConnectionAborted));
                return;
            }

            if (e == null)
            {
                e = new SocketAsyncEventArgs();
            }

            string request;

            try
            {
                var targetDnsEndPoint = targetEndPoint as DnsEndPoint;
                if (targetDnsEndPoint != null)
                {
                    request = string.Format(CultureInfo.InvariantCulture, RequestTemplate, targetDnsEndPoint.Host, targetDnsEndPoint.Port);
                }
                else
                {
                    var targetIPEndPoint = (IPEndPoint)targetEndPoint;
                    request = string.Format(CultureInfo.InvariantCulture, RequestTemplate, targetIPEndPoint.Address, targetIPEndPoint.Port);
                }

                var requestData = Encoding.ASCII.GetBytes(request);

                e.Completed += this.AsyncEventArgsCompleted;
                e.UserToken = new ConnectContext { Socket = socket, SearchState = new SearchMarkState<byte>(lineSeparator) };
                e.SetBuffer(requestData, 0, requestData.Length);

                this.StartSend(socket, e);
            }
            finally
            {
                e.Dispose();
            }
        }

        protected override void ProcessSend(SocketAsyncEventArgs e)
        {
            if (!this.ValidateAsyncResult(e))
            {
                return;
            }

            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            var context = (ConnectContext)e.UserToken;

            var buffer = new byte[this.receiveBufferSize];
            e.SetBuffer(buffer, 0, buffer.Length);

            this.StartReceive(context.Socket, e);
        }

        protected override void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (!this.ValidateAsyncResult(e))
            {
                return;
            }

            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            var context = (ConnectContext)e.UserToken;

            int prevMatched = context.SearchState.Matched;

            int result = e.Buffer.SearchMark(e.Offset, e.BytesTransferred, context.SearchState);

            if (result < 0)
            {
                int total = e.Offset + e.BytesTransferred;

                if (total >= this.receiveBufferSize)
                {
                    this.OnException("receive buffer size has been exceeded");
                    return;
                }

                e.SetBuffer(total, this.receiveBufferSize - total);
                this.StartReceive(context.Socket, e);
                return;
            }

            int responseLength = prevMatched > 0 ? (e.Offset - prevMatched) : (e.Offset + result);

            if (e.Offset + e.BytesTransferred > responseLength + lineSeparator.Length)
            {
                this.OnException("protocol error: more data has been received");
                return;
            }

            string line;

            using (var lineReader = new StringReader(Encoding.ASCII.GetString(e.Buffer, 0, responseLength)))
            {
                line = lineReader.ReadLine();
            }

            if (string.IsNullOrEmpty(line))
            {
                this.OnException("protocol error: invalid response");
                return;
            }

            //// HTTP/1.1 2** OK
            var pos = line.IndexOf(Space);

            if (pos <= 0 || line.Length <= (pos + 2))
            {
                this.OnException("protocol error: invalid response");
                return;
            }

            var httpProtocol = line.Substring(0, pos);

            if (!ResponsePrefix.Equals(httpProtocol))
            {
                this.OnException("protocol error: invalid protocol");
                return;
            }

            var statusPos = line.IndexOf(Space, pos + 1);

            if (statusPos < 0)
            {
                this.OnException("protocol error: invalid response");
                return;
            }

            int statusCode;

            //// Status code should be 2**
            if (!int.TryParse(line.Substring(pos + 1, statusPos - pos - 1), out statusCode) || (statusCode > 299 || statusCode < 200))
            {
                this.OnException("the proxy server refused the connection");
                return;
            }

            this.OnCompleted(new ProxyEventArgs(context.Socket));
        }

        internal class ConnectContext
        {
            public Socket Socket { get; set; }

            public SearchMarkState<byte> SearchState { get; set; }
        }
    }
}