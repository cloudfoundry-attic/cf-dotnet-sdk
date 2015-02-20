using CloudFoundry.CloudController.Common.ServiceLocation;
using CloudFoundry.CloudController.V2.Auth;
using CloudFoundry.CloudController.V2.Client;
using CloudFoundry.CloudController.V2.Interfaces;
using System;
using System.Threading;

namespace CloudFoundry.CloudController.V2
{
    public class CloudFoundryClient
    {
        public AppsEndpoint Apps { get; private set; }

        public AppUsageEventsEndpoint AppUsageEvents { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Buildpacks",
             Justification = "Keeping Cloud Foundry nomenclature.")]
        public BuildpacksEndpoint Buildpacks { get; private set; }

        public DomainsDeprecatedEndpoint DomainsDeprecated { get; private set; }

        public EnvironmentVariableGroupsEndpoint EnvironmentVariableGroups { get; private set; }

        public EventsEndpoint Events { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags",
            Justification = "Keeping Cloud Foundry nomenclature.")]
        public FeatureFlagsEndpoint FeatureFlags { get; private set; }

        public FilesEndpoint Files { get; private set; }

        public InfoEndpoint Info { get; private set; }

        public JobsEndpoint Jobs { get; private set; }

        public OrganizationQuotaDefinitionsEndpoint OrganizationQuotaDefinitions { get; private set; }

        public OrganizationsEndpoint Organizations { get; private set; }

        public PrivateDomainsEndpoint PrivateDomains { get; private set; }

        public ResourceMatchEndpoint ResourceMatch { get; private set; }

        public RoutesEndpoint Routes { get; private set; }

        public SecurityGroupRunningDefaultsEndpoint SecurityGroupRunningDefaults { get; private set; }

        public SecurityGroupsEndpoint SecurityGroups { get; private set; }

        public SecurityGroupStagingDefaultsEndpoint SecurityGroupStagingDefaults { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Auth",
            Justification = "Keeping Cloud Foundry nomenclature.")]
        public ServiceauthtokensDeprecatedEndpoint ServiceAuthTokensDeprecated { get; private set; }

        public ServiceBindingsEndpoint ServiceBindings { get; private set; }

        public ServiceBrokersEndpoint ServiceBrokers { get; private set; }

        public ServiceInstancesEndpoint ServiceInstances { get; private set; }

        public ServicePlansEndpoint ServicePlans { get; private set; }

        public ServicePlanVisibilitiesEndpoint ServicePlanVisibilities { get; private set; }

        public ServicesEndpoint Services { get; private set; }

        public ServiceUsageEventsExperimentalEndpoint ServiceUsageEventsExperimental { get; private set; }

        public SharedDomainsEndpoint SharedDomains { get; private set; }

        public SpaceQuotaDefinitionsEndpoint SpaceQuotaDefinitions { get; private set; }

        public SpacesEndpoint Spaces { get; private set; }

        public StacksEndpoint Stacks { get; private set; }

        public UserProvidedServiceInstancesEndpoint UserProvidedServiceInstances { get; private set; }

        public UsersEndpoint Users { get; private set; }

        internal Uri CloudTarget;
        internal CancellationToken CancellationToken;
        internal IServiceLocator ServiceLocator;
        internal IAuthentication auth;

        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken, IServiceLocator serviceLocator)
        {
            this.CloudTarget = cloudTarget;
            this.CancellationToken = cancellationToken;
            this.ServiceLocator = serviceLocator;
            this.auth = new ThinkTectureAuth();

            this.InitEndpoints();

            var info = this.Info.GetInfo().Result;

            var authUrl = info.AuthorizationEndpoint.TrimEnd('/') + "/oauth/token";
            this.auth.OAuthUrl = new Uri(authUrl);
        }

        public CloudFoundryClient(Uri cloudTarget, CancellationToken cancellationToken)
            : this(cloudTarget, cancellationToken, new ServiceLocator())
        {
        }

        /// <summary>
        /// Logins the specified credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>Refresh Token</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
            Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        public string Login(CloudCredentials credentials)
        {
            var refreshToken = this.auth.Authenticate(credentials);

            return refreshToken;
        }

        /// <summary>
        /// Logins the specified raw token response.
        /// </summary>
        /// <param name="rawTokenResponse">The raw token response.</param>
        /// <returns>Token Object</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Login",
            Justification = "Using the same nomenclature as Cloud Foundry (e.g. cf login)")]
        public string Login(string refreshToken)
        {
            var newRefreshToken = this.auth.Authenticate(refreshToken);
            return newRefreshToken;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling",
            Justification = "Developers using the SDK should find it useful to have a 1-to-1 list of all documented Cloud Foundry endpoints.")]
        private void InitEndpoints()
        {
            this.Apps = new AppsEndpoint(this);
            this.AppUsageEvents = new AppUsageEventsEndpoint(this);
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
            this.ServiceAuthTokensDeprecated = new ServiceauthtokensDeprecatedEndpoint(this);
            this.ServiceBindings = new ServiceBindingsEndpoint(this);
            this.ServiceBrokers = new ServiceBrokersEndpoint(this);
            this.ServiceInstances = new ServiceInstancesEndpoint(this);
            this.ServicePlans = new ServicePlansEndpoint(this);
            this.ServicePlanVisibilities = new ServicePlanVisibilitiesEndpoint(this);
            this.Services = new ServicesEndpoint(this);
            this.ServiceUsageEventsExperimental = new ServiceUsageEventsExperimentalEndpoint(this);
            this.SharedDomains = new SharedDomainsEndpoint(this);
            this.SpaceQuotaDefinitions = new SpaceQuotaDefinitionsEndpoint(this);
            this.Spaces = new SpacesEndpoint(this);
            this.Stacks = new StacksEndpoint(this);
            this.UserProvidedServiceInstances = new UserProvidedServiceInstancesEndpoint(this);
            this.Users = new UsersEndpoint(this);
        }

        public string AuthorizationToken
        {
            get
            {
                return this.auth.GetToken();
            }
        }
    }
}