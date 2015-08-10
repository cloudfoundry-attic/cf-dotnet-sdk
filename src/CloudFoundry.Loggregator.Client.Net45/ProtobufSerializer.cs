namespace CloudFoundry.Loggregator.Client
{
    using System;
    using System.IO;
    using ProtoBuf;
    using ProtoBuf.Meta;

    internal class ProtobufSerializer : IProtobufSerializer
    {
        private RuntimeTypeModel typeModel;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProtobufSerializer()
        {
            //// Protobuf schema:
            //// https://github.com/cloudfoundry/loggregatorlib/blob/5a3c4ae0e4e65d22106db2b03842c3c81c88ae7e/logmessage/log_message.proto

            RuntimeTypeModel model = RuntimeTypeModel.Create();
            Type applicationLogType = typeof(ApplicationLog);

            model.Add(applicationLogType, true);
            model[applicationLogType].Add(1, "Message");
            model[applicationLogType][1].IsRequired = true;

            model[applicationLogType].Add(2, "LogMessageType");
            model[applicationLogType][2].IsRequired = true;

            model[applicationLogType].Add(3, "Timestamp");
            model[applicationLogType][3].IsRequired = true;
            model[applicationLogType][3].DataFormat = DataFormat.ZigZag;

            model[applicationLogType].Add(4, "AppId");
            model[applicationLogType][4].IsRequired = true;

            model[applicationLogType].Add(6, "SourceId");
            model[applicationLogType][6].IsRequired = false;

            model[applicationLogType].Add(7, "DrainUrls");

            model[applicationLogType].Add(8, "SourceName");
            model[applicationLogType][8].IsRequired = false;

            this.typeModel = model;
        }

        /// <summary>
        /// Deserializes an ApplicationLog based on raw data using protobuf
        /// </summary>
        /// <param name="data">byte[] data</param>
        /// <returns>An ApplicationLog instance</returns>
        public ApplicationLog DeserializeApplicationLog(byte[] data)
        {
            Type applicationLogType = typeof(ApplicationLog);
            ApplicationLog log = null;

            using (MemoryStream stream = new MemoryStream(data))
            {
                var result = (ApplicationLog)this.typeModel.Deserialize(stream, log, applicationLogType);
                result.Message = result.Message.Trim(new char[] { '\0' });

                return result;
            }
        }
    }
}
