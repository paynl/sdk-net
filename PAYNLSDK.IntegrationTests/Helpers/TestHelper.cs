using PayNlSdk.Sdk.Client;
using PayNlSdk.Sdk.Idin;

namespace PayNlSdk.IntegrationTests.Helpers;

public static class TestHelper
{
    public static IPayClient CreateClient()
    {
        return new PayClient(Environment.GetEnvironmentVariable("PAY_APIKEY")!, Environment.GetEnvironmentVariable("PAY_AT")!, Environment.GetEnvironmentVariable("PAY_SERVICEID")!);
    }

    public static MultiCorePayClient CreatMultiCoreClient(HttpClient? httpClient = null)
    {
        var client = new MultiCorePayClient(Environment.GetEnvironmentVariable("PAY_APIKEY")!, Environment.GetEnvironmentVariable("PAY_AT")!, Environment.GetEnvironmentVariable("PAY_SERVICEID")!, httpClient);
        client.Initialize();
        return client;
    }

    public static IdinClient CreateIdinClient()
    {
        return new IdinClient(Environment.GetEnvironmentVariable("PAY_APIKEY")!,
            Environment.GetEnvironmentVariable("PAY_AT")!);
    }
}
