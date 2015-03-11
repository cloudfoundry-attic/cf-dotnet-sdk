namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PushProgressEventArgs : EventArgs
    {
        public string Message { get; set; }

        public int Percent { get; set; }
    }
}