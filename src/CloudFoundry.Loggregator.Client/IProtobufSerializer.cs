namespace CloudFoundry.Loggregator.Client
{
    internal interface IProtobufSerializer
    {
        ApplicationLog DeserializeApplicationLog(byte[] data);
    }
}
