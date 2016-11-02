namespace CloudFoundry.CloudController.V2.Client
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;
    using CloudFoundry.CloudController.Common;
    using CloudFoundry.CloudController.Common.Http;
    using CloudFoundry.CloudController.V2.Client.Interfaces;
    using CloudFoundry.UAA;

    /// <summary>
    /// This is the Cloud Foundry client. To use it, you need a Cloud Foundry endpoint.
    /// </summary>
    public sealed class CloudFoundryClient : CloudFoundry.CloudController.Common.CloudFoundryClient, IUAA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient"/> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken)
            : this(cloudTarget, cancellationToken, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy)
            : this(cloudTarget, cancellationToken, httpProxy, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation) 
            : this(cloudTarget, cancellationToken, httpProxy, skipCertificateValidation, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        /// <param name="authorizationUrl">Authorization Endpoint</param>
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation, Uri authorizationUrl)
            : this(cloudTarget, cancellationToken, httpProxy, skipCertificateValidation, authorizationUrl, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        /// <param name="authorizationUrl">Authorization Endpoint</param>
        /// <param name="useStrictStatusCodeChecking">throw exception if the successful http status code returned from the server does not match the expected code</param>
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation, Uri authorizationUrl, bool useStrictStatusCodeChecking)
            : this(cloudTarget, cancellationToken, httpProxy, skipCertificateValidation, authorizationUrl, useStrictStatusCodeChecking, SimpleHttpClient.DefaultTimeout)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFoundryClient" /> class.
        /// </summary>
        /// <param name="cloudTarget">The cloud target.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="httpProxy">The HTTP proxy.</param>
        /// <param name="skipCertificateValidation">if set to <c>true</c> it will skip TLS certificate validation for HTTP requests.</param>
        /// <param name="authorizationUrl">Authorization Endpoint</param>
        /// <param name="useStrictStatusCodeChecking">throw exception if the successful http status code returned from the server does not match the expected code</param>
        /// <param name="requestTimeout">Http requests timeout</param>
        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, Uri httpProxy, bool skipCertificateValidation, Uri authorizationUrl, bool useStrictStatusCodeChecking, TimeSpan requestTimeout)
            : base(cloudTarget, cancellationToken, httpProxy, skipCertificateValidation, authorizationUrl, useStrictStatusCodeChecking, requestTimeout)
        {
        }

        /// <summary>
        /// Gets the apps endpoint.
        /// </summary>
        /// <value>
        /// The apps endpoint.
        /// </value>
        public AppsEndpoint Apps { get; private set; }

        /// <summary>
        /// Gets the application usage events endpoint.
        /// </summary>
        /// <value>
        /// The application usage events endpoint.
        /// </value>
        public AppUsageEventsEndpoint AppUsageEvents { get; private set; }

        /// <summary>
        /// Gets the authorization token. It returns empty string if the client is not authorized. Also this method does not verify if the current token is expired.
        /// </summary>
        /// <value>
        /// The authorization token.
        /// </value>
        public string AuthorizationToken
        {
            get
            {
                if (this.UAAClient == null)
                {
                    return string.Empty;
                }

                return this.UAAClient.Context.Token.AccessToken;
            }
        }

        /// <summary>
        /// Gets the blobstores endpoint.
        /// </summary>
        /// <value>
        /// The blobstores endpoint.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Blobstores",
             Justification = "Keeping Cloud Foundry nomenclature.")]
        public BlobstoresEndpoint Blobstores { get; private set; }

        /// <summary>
        /// Gets the buildpacks endpoint.
        /// </summary>
        /// <value>
        /// The buildpacks endpoint.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Buildpacks",
             Justification = "Keeping Cloud Foundry nomenclature.")]
        public BuildpacksEndpoint Buildpacks { get; private set; }

        /// <summary>
        /// Gets the domains deprecated endpoint.
        /// </summary>
        /// <value>
        /// The domains deprecated endpoint.
        /// </value>
        public DomainsDeprecatedEndpoint DomainsDeprecated { get; private set; }

        /// <summary>
        /// Gets the environment variable groups endpoint.
        /// </summary>
        /// <value>
        /// The environment variable groups endpoint.
        /// </value>
        public EnvironmentVariableGroupsEndpoint EnvironmentVariableGroups { get; private set; }

        /// <summary>
        /// Gets the events endpoint.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        public EventsEndpoint Events { get; private set; }

        /// <summary>
        /// Gets the feature flags endpoint.
        /// </summary>
        /// <value>
        /// The feature flags endpoint.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
            Justification = "Keeping Cloud Foundry nomenclature.")]
        public FeatureFlagsEndpoint FeatureFlags { get; private set; }

        /// <summary>
        /// Gets the files endpoint.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public FilesEndpoint Files { get; private set; }

        /// <summary>
        /// Gets the information endpoint.
        /// </summary>
        /// <value>
        /// The information endpoint.
        /// </value>
        public InfoEndpoint Info { get; private set; }

        /// <summary>
        /// Gets the jobs endpoint.
        /// </summary>
        /// <value>
        /// The jobs endpoint.
        /// </value>
        public JobsEndpoint Jobs { get; private set; }

        /// <summary>
        /// Gets the organization quota definitions endpoint.
        /// </summary>
        /// <value>
        /// The organization quota definitions endpoint.
        /// </value>
        public OrganizationQuotaDefinitionsEndpoint OrganizationQuotaDefinitions { get; private set; }

        /// <summary>
        /// Gets the organizations endpoint.
        /// </summary>
        /// <value>
        /// The organizations endpoint.
        /// </value>
        public OrganizationsEndpoint Organizations { get; private set; }

        /// <summary>
        /// Gets the private domains endpoint.
        /// </summary>
        /// <value>
        /// The private domains endpoint.
        /// </value>
        public PrivateDomainsEndpoint PrivateDomains { get; private set; }

        /// <summary>
        /// Gets the resource match endpoint.
        /// </summary>
        /// <value>
        /// The resource match endpoint.
        /// </value>
        public ResourceMatchEndpoint ResourceMatch { get; private set; }

        /// <summary>
        /// Gets the routes endpoint.
        /// </summary>
        /// <value>
        /// The routes endpoint.
        /// </value>
        public RoutesEndpoint Routes { get; private set; }

        /// <summary>
        /// Gets the security group running defaults endpoint.
        /// </summary>
        /// <value>
        /// The security group running defaults endpoint.
        /// </value>
        public SecurityGroupRunningDefaultsEndpoint SecurityGroupRunningDefaults { get; private set; }

        /// <summary>
        /// Gets the security groups endpoint.
        /// </summary>
        /// <value>
        /// The security groups endpoint.
        /// </value>
        public SecurityGroupsEndpoint SecurityGroups { get; private set; }

        /// <summary>
        /// Gets the security group staging defaults endpoint.
        /// </summary>
        /// <value>
        /// The security group staging defaults endpoint.
        /// </value>
        public SecurityGroupStagingDefaultsEndpoint SecurityGroupStagingDefaults { get; private set; }

        /// <summary>
        /// Gets the service bindings endpoint.
        /// </summary>
        /// <value>
        /// The service bindings endpoint.
        /// </value>
        public ServiceBindingsEndpoint ServiceBindings { get; private set; }

        /// <summary>
        /// Gets the service brokers endpoint.
        /// </summary>
        /// <value>
        /// The service brokers endpoint.
        /// </value>
        public ServiceBrokersEndpoint ServiceBrokers { get; private set; }

        /// <summary>
        /// Gets the service instances endpoint.
        /// </summary>
        /// <value>
        /// The service instances endpoint.
        /// </value>
        public ServiceInstancesEndpoint ServiceInstances { get; private set; }

        /// <summary>
        /// Gets the service keys endpoint.
        /// </summary>
        /// <value>
        /// The service keys endpoint.
        /// </value>
        public ServiceKeysEndpoint ServiceKeys { get; private set; }

        /// <summary>
        /// Gets the service plans endpoint.
        /// </summary>
        /// <value>
        /// The service plans endpoint.
        /// </value>
        public ServicePlansEndpoint ServicePlans { get; private set; }

        /// <summary>
        /// Gets the service plan visibilities endpoint. 
        /// </summary>
        /// <value>
        /// The service plan visibilities endpoint.
        /// </value>
        public ServicePlanVisibilitiesEndpoint ServicePlanVisibilities { get; private set; }

        /// <summary>
        /// Gets the services endpoint.
        /// </summary>
        /// <value>
        /// The services endpoint.
        /// </value>
        public ServicesEndpoint Services { get; private set; }

        /// <summary>
        /// Gets the service usage events experimental endpoint.
        /// </summary>
        /// <value>
        /// The service usage events experimental endpoint.
        /// </value>
        public ServiceUsageEventsEndpoint ServiceUsageEvents { get; private set; }

        /// <summary>
        /// Gets the shared domains endpoint.
        /// </summary>
        /// <value>
        /// The shared domains endpoint.
        /// </value>
        public SharedDomainsEndpoint SharedDomains { get; private set; }

        /// <summary>
        /// Gets the space quota definitions endpoint.
        /// </summary>
        /// <value>
        /// The space quota definitions endpoint.
        /// </value>
        public SpaceQuotaDefinitionsEndpoint SpaceQuotaDefinitions { get; private set; }

        /// <summary>
        /// Gets the spaces endpoint.
        /// </summary>
        /// <value>
        /// The spaces endpoint.
        /// </value>
        public SpacesEndpoint Spaces { get; private set; }

        /// <summary>
        /// Gets the stacks endpoint.
        /// </summary>
        /// <value>
        /// The stacks endpoint.
        /// </value>
        public StacksEndpoint Stacks { get; private set; }

        /// <summary>
        /// Gets the user provided service instances endpoint.
        /// </summary>
        /// <value>
        /// The user provided service instances endpoint.
        /// </value>
        public UserProvidedServiceInstancesEndpoint UserProvidedServiceInstances { get; private set; }

        /// <summary>
        /// Gets the users endpoint.
        /// </summary>
        /// <value>
        /// The users endpoint.
        /// </value>
        public UsersEndpoint Users { get; private set; }

        /// <inheritdoc />
        public UAAClient UAAClient { get; private set; }

        /// <summary>
        /// Login using the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>Refresh Token</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
            Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        public async Task<AuthenticationContext> Login(CloudCredentials credentials)
        {
            if (this.AuthorizationEndpoint == null)
            {
                var info = await this.Info.GetInfo();

                this.AuthorizationEndpoint = new Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}", info.AuthorizationEndpoint.TrimEnd('/'), "/oauth/token"));
            }

            this.UAAClient = new UAAClient(this.AuthorizationEndpoint, this.HttpProxy, this.SkipCertificateValidation);

            var context = await this.UAAClient.Login(credentials);

            if (context.IsLoggedIn)
            {
                //// Workaround for HCF. Some CC requests (e.g. dev role + bind route, update app, etc..) will fail the first time after login with 401.
                //// Calling the CC's /v2/info endpoint will prevent this misbehavior.
                await this.Info.GetInfo();
            }

            return context;
        }

        /// <summary>
        /// Gets the authorization token. If the client is not authorized, an empty string is returned. If the token is expired, it generates a new one.
        /// </summary>
        /// <value>
        /// The authorization token.
        /// </value>
        public async Task<string> GenerateAuthorizationToken()
        {
            if (this.UAAClient == null)
            {
                return string.Empty;
            }

            if (this.UAAClient.Context.Token.IsExpired)
            {
                var context = await this.UAAClient.GenerateContext();
            }

            return this.UAAClient.Context.Token.AccessToken;
        }

        /// <summary>
        /// Login using the specified raw token.
        /// </summary>
        /// <param name="refreshToken">A raw token.</param>
        /// <returns>Token Object</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
            Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        public async Task<AuthenticationContext> Login(string refreshToken)
        {
            if (this.AuthorizationEndpoint == null)
            {
                var info = await this.Info.GetInfo();

                this.AuthorizationEndpoint = new Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}", info.AuthorizationEndpoint.TrimEnd('/'), "/oauth/token"));
            }

            this.UAAClient = new UAAClient(this.AuthorizationEndpoint, this.HttpProxy, this.SkipCertificateValidation);

            var context = await this.UAAClient.Login(refreshToken);

            if (context.IsLoggedIn)
            {
                //// Workaround for HCF. Some CC requests (e.g. dev role + bind route, update app, etc..) will fail the first time after login with 401.
                //// Calling the CC's /v2/info endpoint will prevent this misbehavior.
                await this.Info.GetInfo();
            }

            return context;
        }

        /// <summary>
        /// Initializes all API Endpoints
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling",
            Justification = "Developers using the SDK should find it useful to have a 1-to-1 list of all documented Cloud Foundry endpoints.")]
        public override void InitEndpoints()
        {
            this.Apps = new AppsEndpoint(this);
            this.AppUsageEvents = new AppUsageEventsEndpoint(this);
            this.Blobstores = new BlobstoresEndpoint(this);
            this.Buildpacks = new BuildpacksEndpoint(this);
            this.DomainsDeprecated = new DomainsDeprecatedEndpoint(this);
            this.EnvironmentVariableGroups = new EnvironmentVariableGroupsEndpoint(this);
            this.Events = new EventsEndpoint(this);
            this.FeatureFlags = new FeatureFlagsEndpoint(this);
            this.Files = new FilesEndpoint(this);
            this.Info = new InfoEndpoint(this);
            this.Jobs = new JobsEndpoint(this);
            this.OrganizationQuotaDefinitions = new OrganizationQuotaDefinitionsEndpoint(this);
            this.Organizations = new OrganizationsEndpoint(this);
            this.PrivateDomains = new PrivateDomainsEndpoint(this);
            this.ResourceMatch = new ResourceMatchEndpoint(this);
            this.Routes = new RoutesEndpoint(this);
            this.SecurityGroupRunningDefaults = new SecurityGroupRunningDefaultsEndpoint(this);
            this.SecurityGroups = new SecurityGroupsEndpoint(this);
            this.SecurityGroupStagingDefaults = new SecurityGroupStagingDefaultsEndpoint(this);
            this.ServiceBindings = new ServiceBindingsEndpoint(this);
            this.ServiceBrokers = new ServiceBrokersEndpoint(this);
            this.ServiceInstances = new ServiceInstancesEndpoint(this);
            this.ServiceKeys = new ServiceKeysEndpoint(this);
            this.ServicePlans = new ServicePlansEndpoint(this);
            this.ServicePlanVisibilities = new ServicePlanVisibilitiesEndpoint(this);
            this.Services = new ServicesEndpoint(this);
            this.ServiceUsageEvents = new ServiceUsageEventsEndpoint(this);
            this.SharedDomains = new SharedDomainsEndpoint(this);
            this.SpaceQuotaDefinitions = new SpaceQuotaDefinitionsEndpoint(this);
            this.Spaces = new SpacesEndpoint(this);
            this.Stacks = new StacksEndpoint(this);
            this.UserProvidedServiceInstances = new UserProvidedServiceInstancesEndpoint(this);
            this.Users = new UsersEndpoint(this);
        }
    }
}