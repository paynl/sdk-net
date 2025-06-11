using Microsoft.Extensions.Configuration;
using PayNlSdk.Sdk.V2.Client;
using PayNlSdk.Sdk.V2.Idin;
using PayNlSdk.Sdk.V3.Client;

namespace PayNlSdk.IntegrationTests.Helpers;

public static class TestHelper
{
	private static readonly IConfiguration Config = new ConfigurationBuilder()
		.AddUserSecrets("fe223c57-4274-4dd5-8f39-ac6534955c37")
		.AddEnvironmentVariables()
		.Build();

	public static IPayV3Client CreateClientV3()
	{
		return new PayV3Client(Config["PAY_APIKEY"]!, Config["PAY_AT"]!, Config["PAY_SERVICEID"]!);
	}

	public static IPayV2Client CreateClientV2()
	{
		return new PayV2Client(Config["PAY_APIKEY"]!, Config["PAY_AT"]!, Config["PAY_SERVICEID"]!);
	}

	public static MultiCorePayV2Client CreatMultiCoreClient(HttpClient? httpClient = null)
	{
		var client = new MultiCorePayV2Client(Config["PAY_APIKEY"]!, Config["PAY_AT"]!, Config["PAY_SERVICEID"]!, httpClient);
		client.Initialize();
		return client;
	}

	public static IdinClient CreateIdinClient()
	{
		return new IdinClient(Config["PAY_APIKEY"]!, Config["PAY_AT"]!);
	}
}
