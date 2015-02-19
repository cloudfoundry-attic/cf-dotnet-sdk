using System;

namespace CloudFoundry.CloudController.Common.Http
{
    public class DisposableClass : IDisposable
    {
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableClass()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            //if (disposing)
            //{

            //}

            _disposed = true;
        }
    }
}
