namespace CloudFoundry.CloudController.V2.Client.Data
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using CloudFoundry.CloudController.V2.Client.Interfaces;
    using Newtonsoft.Json;

    public partial class ListAllMatchingResourcesRequest
    {
        /// <summary> 
        /// <para>The Sha1</para>
        /// </summary>
        [JsonProperty("sha1", NullValueHandling = NullValueHandling.Ignore)]
        public new string Sha1
        {
            get;
            set;
        }

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