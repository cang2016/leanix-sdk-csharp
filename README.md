# LeanIX SDK for C#

LeanIX API version v1, https://developer.leanix.net

## Overview

This SDK contains wrapper code used to call the LeanIX REST API from C#.

The SDK also contains a simple example. The code in [samples/client/SampleClient/SampleClient.cs](samples/client/SampleClient/SampleClient.cs) demonstrates the basic use of the SDK to read Applications from the LeanIX Inventory.

## Prerequisites

### API Token
In order to use the code in this SDK, you need an API token to access a workspace. As a workspace administrator, you can generate it yourself in the LeanIX application under Administration.

The API token acts as credentials to access a LeanIX workspace as the user who generated the token. Hence you should take care to keep it private, for example by using a password safe application.

The LeanIX REST API uses OAuth2 access tokens to protect its resources. The SDK transparently uses the API token that is set in the ApiClient to obtain such an access token from the token provider. The host name of the token provider is normally "svc.leanix.net".

### Swagger documentation
You can find the LeanIX REST API documentation here https://app.leanix.net/demo/api/v1/. The documentation is interactive - if you are logged in to your workspace and the REST API is activated, you can try out every function directly from the documentation.

## Including the SDK in your project

The easiest way to incorporate the SDK into your C# project is to create a reference to the C#-Project LeanIX.Api.csproj. Please note, that the project required .NET Framework 4.5.

## Usage

In order to use the SDK in your C# application, import the following namespaces:

```
  using LeanIX.Api;
  using LeanIX.Api.Models;
  using LeanIX.Api.Common;
```

You need to instantiate a LeanIX API Client. Here you define the URL to the REST API of your workspace. Please replace `demo` with the name of your workspace. Also here you need to provide the API token.

```
  ApiClient client = new ApiClientBuilder()
    .WithBasePath("https://app.leanix.net/demo/api/v1")
    .WithTokenProviderHost("svc.leanix.net")
    .WithApiToken("bfh7E9h5wrqJtxb5urptjXJ6bZQjgVSRk6PCYf6X")
    .Build();
```

You can then use the API class to execute functions. For each Fact Sheet in LeanIX there is one API class, e.g. for the Fact Sheet "Application" the API class is called `ServicesApi`. To print the names of all applications which match the full-text search of "design", you could do the following:

```
  ServicesApi api = new ServicesApi();
  List<Service> services = api.getServices(false, "design");

  foreach (Service s in services)
  {
    System.Console.WriteLine(s.ID + " " + s.name);
  }
```

## Update the SDK

In order to update the SDK, you need to have java 7 and maven installed, you can then run the following command in the root of the project:

```
  cd codegen
  mvn package
```

In order to test whether the compilation of the generated sources works, adapt the code in [samples/client/SampleClient/SampleClient.cs](samples/client/SampleClient/SampleClient.cs) to use the correct instance and API Token and run:

```
  ./test-compile.sh
```

You should see some Applications from the LeanIX inventory to be printed out by the program.

# Thank You

This API made use of the swagger-* libraries which help you to describe REST APIs in an elegant way. See here for more details: https://github.com/wordnik/swagger-codegen

# Copyright and license

Copyright 2015, 2016 LeanIX GmbH under [the MIT license](LICENSE).
