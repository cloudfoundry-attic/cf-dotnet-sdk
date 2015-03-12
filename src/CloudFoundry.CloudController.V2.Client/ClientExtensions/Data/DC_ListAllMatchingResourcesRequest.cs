namespace CloudFoundry.CloudController.V2.Client.Data
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using CloudFoundry.CloudController.V2.Interfaces;
    using Newtonsoft.Json;

    public partial class ListAllMatchingResourcesRequest
    {
        /// <summary> 
        /// <para>The Size</para>
        /// </summary>
        [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
        public new long? Size
        {
            get;
            set;
        }
    }
}