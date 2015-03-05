namespace CloudFoundry.Logyard.Client
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    internal class JsonUtilities
    {
        private JsonUtilities()
        {
        }

        public static Message DeserializeLogyardMessage(string message)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            Message msg = JsonConvert.DeserializeObject<Message>(message, settings);

            if (!string.IsNullOrEmpty(msg.Error))
            {
                return msg;
            }

            var obj = JObject.Parse(message);
            var value = JObject.Parse(obj["value"].ToString());
            msg.Value = value.ToObject<MessageValue>();
            var syslog = JObject.Parse(value["syslog"].ToString());
            msg.Value.Syslog = syslog.ToObject<ValueSyslog>();

            return msg;
        }
    }
}