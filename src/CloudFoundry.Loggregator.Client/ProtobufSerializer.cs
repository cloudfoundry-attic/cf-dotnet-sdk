namespace CloudFoundry.Loggregator.Client
{
    using System;

    internal class ProtobufSerializer : IProtobufSerializer
    {
        /// <summary>
        /// Deserializes an ApplicationLog based on raw data using protobuf
        /// </summary>
        /// <param name="data">byte[] data</param>
        /// <returns>An ApplicationLog instance</returns>
        public ApplicationLog DeserializeApplicationLog(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
