using System;
using System.Collections.Generic;
using LeanIX.Api;
using LeanIX.Api.Models;
using LeanIX.Api.Common;

class SampleClient
{
    static void Main(string[] args)
    {
        try
        {
            ApiClient client = new ApiClientBuilder()
                .WithBasePath("https://app.leanix.net/demo/api/v1")
                .WithTokenProviderHost("app.leanix.net")
                .WithApiToken("bfh7E9h5wrqJtxb5urptjXJ6bZQjgVSRk6PCYf6X")
                .Build();

            ServicesApi api = new ServicesApi();
            List<Service> services = api.getServices(false, "design");
            foreach (Service s in services)
            {
                System.Console.WriteLine(s.ID + " " + s.name);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }

        System.Console.ReadLine();
    }
}
