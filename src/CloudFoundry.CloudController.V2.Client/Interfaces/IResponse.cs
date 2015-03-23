namespace CloudFoundry.CloudController.V2.Client.Interfaces
{
    /// <summary>
    ///  Represent a part of the response message.
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// Gets or sets the entity metadata.
        /// </summary>
        /// <value>
        /// The entity metadata.
        /// </value>
        Metadata EntityMetadata { get; set; }
    }
}