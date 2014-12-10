using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using cf_net_sdk.Interfaces;

namespace cf_net_sdk.Client.Data
{
public class ListAllServiceBindingsForAppResponse :IResponse
{

    public Metadata EntityMetadata
    {
    get;
    set;
    }



    [JsonProperty("app_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid AppGuid
    {
    get;
    set;
    }

    [JsonProperty("service_instance_guid", NullValueHandling=NullValueHandling.Ignore)]
    public Guid ServiceInstanceGuid
    {
    get;
    set;
    }

    [JsonProperty("credentials", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<string, string> Credentials
    {
    get;
    set;
    }

    [JsonProperty("binding_options", NullValueHandling=NullValueHandling.Ignore)]
    public Dictionary<dynamic, dynamic> BindingOptions
    {
    get;
    set;
    }

    [JsonProperty("gateway_data", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic GatewayData
    {
    get;
    set;
    }

    [JsonProperty("gateway_name", NullValueHandling=NullValueHandling.Ignore)]
    public string GatewayName
    {
    get;
    set;
    }

    [JsonProperty("syslog_drain_url", NullValueHandling=NullValueHandling.Ignore)]
    public dynamic SyslogDrainUrl
    {
    get;
    set;
    }

    [JsonProperty("app_url", NullValueHandling=NullValueHandling.Ignore)]
    public string AppUrl
    {
    get;
    set;
    }

    [JsonProperty("service_instance_url", NullValueHandling=NullValueHandling.Ignore)]
    public string ServiceInstanceUrl
    {
    get;
    set;
    }

}
}