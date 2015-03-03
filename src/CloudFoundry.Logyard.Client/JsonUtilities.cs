using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudFoundry.Logyard.Client
{
    internal class JsonUtilities
    {
        public static Message DeserializaeLogyardMessage(string message)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            Message msg = JsonConvert.DeserializeObject<Message>(message, settings);

            if(msg.Error != string.Empty)
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