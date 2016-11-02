namespace CloudFoundry.Doppler.Client
{
    using System;
    using System.IO;
    using DropsondeProtocol;
    using ProtoBuf;
    using ProtoBuf.Meta;

    internal class ProtobufSerializer
    {
        private RuntimeTypeModel typeModel;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProtobufSerializer()
        {
            RuntimeTypeModel model = RuntimeTypeModel.Create();
            Type envelopeType = typeof(Envelope);
            model.Add(envelopeType, true);

            this.typeModel = model;
        }

        /// <summary>
        /// Deserializes an ApplicationLog based on raw data using protobuf
        /// </summary>
        /// <param name="data">byte[] data</param>
        /// <returns>An ApplicationLog instance</returns>
        public Envelope DeserializeEnvelope(byte[] data)
        {
            Type applicationLogType = typeof(Envelope);
            Envelope log = null;

            using (MemoryStream stream = new MemoryStream(data))
            {
                var result = (Envelope)this.typeModel.Deserialize(stream, log, applicationLogType);

                return result;
            }
        }
    }
}
