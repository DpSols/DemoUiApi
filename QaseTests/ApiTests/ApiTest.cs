using NUnit.Framework;
using QaseTests.AppConfigurations;
using RestSharp;

namespace QaseTests.ApiTests;

public abstract class ApiTest
{
    protected readonly RestClient RestClient;

    protected ApiTest()
    {
        RestClient = new RestClient(AppProperties.ApiUrl);
        RestClient.AddDefaultHeader("token", AppProperties.Token);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        RestClient.Dispose();
    }
}