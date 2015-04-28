namespace WebSocket4Net.ProxyUtilities
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using SuperSocket.ClientEngine;

    // Source: https://github.com/kerryjiang/SuperSocket.ClientEngine/blob/42d5974a46e2f57815dd91cef759bd70a9acd475/Proxy/ProxyConnectorBase.cs
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1012:AbstractTypesShouldNotHaveConstructors", Justification = "Keep similar style with upstream")]
    public abstract class ProxyConnectorBase : IProxyConnector
    {
        private EventHandler<ProxyEventArgs> completed;

        public ProxyConnectorBase(EndPoint proxyEndPoint)
        {
            this.ProxyEndPoint = proxyEndPoint;
        }

        public event EventHandler<ProxyEventArgs> Completed
        {
            add { this.completed += value; }
            remove { this.completed -= value; }
        }

        public EndPoint ProxyEndPoint { get; private set; }

        public abstract void Connect(EndPoint remoteEndPoint);

        protected void OnCompleted(ProxyEventArgs args)
        {
            if (this.completed == null)
            {
                return;
            }

            this.completed(this, args);
        }

        protected void OnException(Exception exception)
        {
            this.OnCompleted(new ProxyEventArgs(exception));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Justification = "Keep similar style with upstream")]
        protected void OnException(string exception)
        {
            this.OnCompleted(new ProxyEventArgs(new Exception(exception)));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Justification = "Keep similar style with upstream")]
        protected bool ValidateAsyncResult(SocketAsyncEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            if (e.SocketError != SocketError.Success)
            {
                var socketException = new SocketException((int)e.SocketError);
                this.OnCompleted(new ProxyEventArgs(new Exception(socketException.Message, socketException)));
                return false;
            }

            return true;
        }

        protected void AsyncEventArgsCompleted(object sender, SocketAsyncEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            if (e.LastOperation == SocketAsyncOperation.Send)
            {
                this.ProcessSend(e);
            }
            else
            {
                this.ProcessReceive(e);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Keep similar style with upstream"),
        System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Justification = "Keep similar style with upstream")]
        protected void StartSend(Socket socket, SocketAsyncEventArgs e)
        {
            if (socket == null)
            {
                throw new ArgumentNullException("socket");
            }

            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            bool raiseEvent = false;

            try
            {
                raiseEvent = socket.SendAsync(e);
            }
            catch (Exception exc)
            {
                this.OnException(new Exception(exc.Message, exc));
                return;
            }

            if (!raiseEvent)
            {
                this.ProcessSend(e);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Keep similar style with upstream"),
        System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes", Justification = "Keep similar style with upstream")]
        protected virtual void StartReceive(Socket socket, SocketAsyncEventArgs e)
        {
            if (socket == null)
            {
                throw new ArgumentNullException("socket");
            }

            if (e == null)
            {
                throw new ArgumentNullException("e");
            }

            bool raiseEvent = false;

            try
            {
                raiseEvent = socket.ReceiveAsync(e);
            }
            catch (Exception exc)
            {
                this.OnException(new Exception(exc.Message, exc));
                return;
            }

            if (!raiseEvent)
            {
                this.ProcessReceive(e);
            }
        }

        protected abstract void ProcessConnect(Socket socket, object targetEndPoint, SocketAsyncEventArgs e);

        protected abstract void ProcessSend(SocketAsyncEventArgs e);

        protected abstract void ProcessReceive(SocketAsyncEventArgs e);
    }
}