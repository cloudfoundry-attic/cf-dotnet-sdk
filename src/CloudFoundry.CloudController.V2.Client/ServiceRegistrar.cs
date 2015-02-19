using CloudFoundry.CloudController.V2;
using CloudFoundry.CloudController.V2.Interfaces;
using CloudFoundry.CloudController.Common.Http;
using CloudFoundry.CloudController.Common.ServiceLocation;

namespace CloudFoundry
{
    /// <inheritdoc/>
    public class ServiceRegistrar : IServiceLocationRegistrar
    {
        /// <inheritdoc/>
        public void Register(IServiceLocationManager manager, IServiceLocator locator)
        {
            //Common
            manager.RegisterServiceInstance(typeof(IHttpAbstractionClientFactory), new HttpAbstractionClientFactory());                                    
        }
    }
}
