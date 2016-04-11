# leanIX SDK for C#

leanIX API version v1, https://developer.leanix.net

## Overview

This SDK contains wrapper code used to call the leanIX REST API from C#.

The SDK also contains a simple example. The code in [samples/client/SampleClient/SampleClient.cs](samples/client/SampleClient/SampleClient.cs) demonstrates the basic use of the SDK to read Applications from the leanIX Inventory.

## Prerequisites

In order to use the code in this SDK, the REST API needs to be activated in your workspace and you need your personal API Key. When you are logged in to leanIX, please go to your profile (click on the user icon in the top menu). You find a menu entry called "API / 3rd party apps". If the REST API is activated, you can generate an API Key here.

You can find the leanIX REST API documentation here https://developer.leanix.net. The documentation is interactive - if you are logged in to your workspace and the REST API is activated, you can try out every function directly from the documentation.

## Including the SDK in your project

The easiest way to incorporate the SDK into your C# project is to create a reference to the C#-Project LeanIX.Api.csproj. Please note, that the project required .NET Framework 4.5.

## Usage

In order to use the SDK in your C# application, import the following namespaces:

	using LeanIX.Api;
	using LeanIX.Api.Models;
	using LeanIX.Api.Common;

You need to instantiate a leanIX API Client. Here you define the URL to the REST API of your workspace. Please replace `demo` with the name of your workspace. Also here you need to provide the Api-Key.

	ApiClient client = ApiClient.GetInstance();
	client.setBasePath("https://app.leanix.net/demo/api/v1");
	client.setApiKey("31c7cfa0b5cb755f4c7f146c92d0ad6b");

You can then use the API class to execute functions. For each Fact Sheet in leanIX there is one API class, e.g. for the Fact Sheet "Application" the API class is called `ServicesApi`. To print the names of all applications which match the full-text search of "design", you could do the following:

	ServicesApi api = new ServicesApi();
	List<Service> services = api.getServices(false, "");

	foreach (Service s in services)
	{
		System.Console.WriteLine(s.ID + " " + s.name);
	}

## Update the SDK

In order to update the SDK, you need to have maven installed, you can then run the following command in the root of the project:

	cd codegen
	mvn package

# Thank You

This API made use of the swagger-* libraries which help you to describe REST APIs in an elegant way. See here for more details: https://github.com/wordnik/swagger-codegen

# Copyright and license

Copyright 2015 LeanIX GmbH under [the MIT license](LICENSE).
