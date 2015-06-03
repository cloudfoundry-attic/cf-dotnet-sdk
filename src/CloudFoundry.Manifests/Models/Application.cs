namespace CloudFoundry.Manifests.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Class that contains properties of a application in a CloudFoundry manifest
    /// </summary>
    public class Application
    {
        private string[] services;
        private string[] domains;
        private string[] hosts;

        /// <summary>
        /// Creates a new instance of an Application
        /// </summary>
        public Application()
        {
            this.EnvironmentVariables = new Dictionary<string, string>();
        }

        /// <summary>
        /// Name of the application
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Path of the application directory
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Name of the stack
        /// </summary>
        public string StackName { get; set; }

        /// <summary>
        /// Memory quota in Megabytes
        /// </summary>
        public long? Memory { get; set; }

        /// <summary>
        /// Number of instances
        /// </summary>
        public int? InstanceCount { get; set; }

        /// <summary>
        /// Url of a custom buildpack
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Used for deserialization")]
        public string BuildpackUrl { get; set; }

        /// <summary>
        /// Wait for the application to start for this amount of seconds
        /// </summary>
        public int? HealthCheckTimeout { get; set; }

        /// <summary>
        /// Custom start command
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Disk Quota in Megabytes
        /// </summary>
        public long? DiskQuota { get; set; }

        /// <summary>
        /// Pulish app without a route
        /// </summary>
        public bool NoRoute { get; set; }

        /// <summary>
        /// Publish app witout a Host Name
        /// </summary>
        public bool NoHostName { get; set; }

        /// <summary>
        /// Publish app with a random Host Name
        /// </summary>
        public bool UseRandomHostName { get; set; }

        /// <summary>
        /// Returns the apps environment variables
        /// </summary>
        public Dictionary<string, string> EnvironmentVariables { get; internal set; }

        /// <summary>
        /// Sets a value for a environment variable
        /// </summary>
        /// <param name="key">Name of the variable</param>
        /// <param name="value">Value of the variable</param>
        public void SetEnvironmentVariable(string key, string value)
        {
            this.EnvironmentVariables[key] = value;
        }

        /// <summary>
        /// Sets the applicatoins services
        /// </summary>
        /// <param name="value">Array containing service names</param>
        public void SetServices(string[] value)
        {
            this.services = value;
        }

        /// <summary>
        /// Gets the applications services
        /// </summary>
        /// <returns>Array containing service names</returns>
        public string[] GetServices()
        {
            return (string[])this.services.Clone();
        }

        /// <summary>
        /// Sets the applications domains
        /// </summary>
        /// <param name="value">Array containing domain names</param>
        public void SetDomains(string[] value)
        {
            this.domains = value;
        }

        /// <summary>
        /// Gets the applications domains
        /// </summary>
        /// <returns>Array containing domain names</returns>
        public string[] GetDomains()
        {
            return (string[])this.domains.Clone();
        }

        /// <summary>
        /// Sets the applications host names
        /// </summary>
        /// <param name="value">Array containing host names</param>
        public void SetHosts(string[] value)
        {
            this.hosts = value;
        }

        /// <summary>
        /// Gets the applications host names
        /// </summary>
        /// <returns>Array containing host names</returns>
        public string[] GetHosts()
        {
            return (string[])this.hosts.Clone();
        }
    }
}