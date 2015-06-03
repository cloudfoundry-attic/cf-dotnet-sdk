#Cloud Foundry .NET SDK
The CloudFoundry .NET SDK allows you to easily access the the CloudController API from within your .NET Application

The full CF API Documentation is available at http://apidocs.cloudfoundry.org/

## Getting Started

### Target Frameworks
- .NET Framework 4.5 Portable Class Library

### Prerequisites
- Visual Studio 2013 Update 2 or newer
- Git client

### Contribute

#### Build it locally
- Clone the repo `git clone https://github.com/hpcloud/cf-dotnet-sdk`
- Build the cf-dotnet-sdk.sln in Visual Studio 2013

#### Test your build

##### Unit tests
Run all tests inside the **CloudFoundry.CloudController.V2.Client.Test** project

##### Integration tests
If you have a working CloundFoundry environment you can run the integration tests within the **CloudFoundry.CloudController.Test.Integration** project.

Before running the integration tests, make sure you set you connection info in the app.config

#### How to contribute
We are looking forward to contributions from the community.

Feel free to open an pull request or create an issue.

### Use the nuget package
- Add nuget repo **http://nuget.15.126.229.131.xip.io/nuget/** to the package sources 
- Add package to your project `Install-Package CloudFoundry.CloudController.V2.Client`

## Code Samples

### Login
```csharp
// use this only if your api is using an unsigned certificate
System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

CloudFoundryClient client = new CloudFoundryClient(new Uri("https://api.domain"), new System.Threading.CancellationToken());
AuthenticationContext refreshToken = null;
CloudCredentials credentials = new CloudCredentials();
credentials.User = "user";
credentials.Password = "password";
try
{
    refreshToken = client.Login(credentials).Result;
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
```

### List Apps
```csharp     
PagedResponseCollection<ListAllAppsResponse> apps = client.Apps.ListAllApps().Result;
while (apps != null && apps.Properties.TotalResults != 0)
{
    foreach (var app in apps)
    {
        Console.WriteLine("Application {0}, guid {1}, state {2}", app.Name, app.EntityMetadata.Guid, app.State);
    }
    apps = apps.GetNextPage().Result;
}
```

### Stop an App
```csharp
Guid appGuid = new Guid("52b6b758-848b-4b8d-b3f2-83736b5fae68");            
UpdateAppRequest updateApp = new UpdateAppRequest();
updateApp.State = "STOPPED";
UpdateAppResponse response = client.Apps.UpdateApp(appGuid, updateApp).Result;
Console.WriteLine("App {0} state is {1}", response.Name, response.State);
```
### Load a cf manifest
```csharp
using CloudFoundry.Manifests;

Manifest manifest = ManifestDiskRepository.ReadManifest("path\to\manifest");
var apps = manifest.Applications();
foreach(var app in apps)
{
    Console.WriteLine("Application {0}, Memory {1}, Instances {2}", app.Name, app.Memory.ToString(), app.InstanceCount.ToString());
}
```