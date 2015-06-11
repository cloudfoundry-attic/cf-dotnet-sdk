namespace CloudFoundry.Manifests.Models
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Class that contains properties of a application in a CloudFoundry manifest
    /// </summary>
    public class Application
    {
        private ArrayList domains = new ArrayList();
        private ArrayList hosts = new ArrayList();
        private ArrayList services = new ArrayList();

        /// <summary>
        /// Creates a new instance of an Application
        /// </summary>
        public Application()
        {
            this.EnvironmentVariables = new Dictionary<string, string>();
        }

        /// <summary>
        /// Url of a custom buildpack
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings", Justification = "Used for deserialization")]
        public string BuildpackUrl { get; set; }

        /// <summary>
        /// Custom start command
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Disk Quota in Megabytes
        /// </summary>
        public long? DiskQuota { get; set; }

        /// <summary>
        /// Collection containing domain names
        /// </summary>
        public ArrayList Domains
        {
            get { return this.domains; }
        }

        /// <summary>
        /// Returns the apps environment variables
        /// </summary>
        public Dictionary<string, string> EnvironmentVariables { get; internal set; }

        /// <summary>
        /// Wait for the application to start for this amount of seconds
        /// </summary>
        public int? HealthCheckTimeout { get; set; }

        /// <summary>
        /// Gets the applications host names
        /// </summary>
        public ArrayList Hosts
        {
            get { return this.hosts; }
        }

        /// <summary>
        /// Number of instances
        /// </summary>
        public int? InstanceCount { get; set; }

        /// <summary>
        /// Memory quota in Megabytes
        /// </summary>
        public long? Memory { get; set; }

        /// <summary>
        /// Name of the application
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Publish app witout a Host Name
        /// </summary>
        public bool NoHostName { get; set; }

        /// <summary>
        /// Pulish app without a route
        /// </summary>
        public bool NoRoute { get; set; }

        /// <summary>
        /// Path of the application directory
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets the applications services
        /// </summary>
        public ArrayList Services
        {
            get { return this.services; }
        }

        /// <summary>
        /// Name of the stack
        /// </summary>
        public string StackName { get; set; }

        /// <summary>
        /// Publish app with a random Host Name
        /// </summary>
        public bool UseRandomHostName { get; set; }

        /// <summary>
        /// Sets a value for a environment variable
        /// </summary>
        /// <param name="key">Name of the variable</param>
        /// <param name="value">Value of the variable</param>
        public void SetEnvironmentVariable(string key, string value)
        {
            this.EnvironmentVariables[key] = value;
        }
    }
}