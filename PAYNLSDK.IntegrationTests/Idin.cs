using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.Idin.Requests;
#pragma warning disable CS8604 // Possible null reference argument.

namespace PayNlSdk.IntegrationTests;

public class Idin
{
    [Fact]
    public async Task CanListIdinIssuers()
    {
        var client = TestHelper.CreateIdinClient();

        var response = await client.ListIssuers();

        Assert.NotNull(response);
        Assert.NotNull(response.Request);
        Assert.NotNull(response.Issuers);
        Assert.NotEmpty(response.Issuers);
    }

    [Fact]
    public async Task CanAuthenticate()
    {
        var client = TestHelper.CreateIdinClient();
        var issuer = await client.ListIssuers();

        var trx = await client.Authenticate(new IdinAuthenticationRequest
        {
            ServiceId = Environment.GetEnvironmentVariable("PAY_SERVICEID")!,
            Reference = "Reference",
            IssuerId = issuer.Issuers.First().Key,
            Data = new IdinAuthenticationData
            {
                Address = true,
                DateOfBirth = true,
                Email = true,
                Gender = true,
                Name = true,
                Phone = true,
                IsEighteen = true,
            },
            ReturnUrl = "https://www.google.com"
        });

        Assert.NotNull(trx);
    }

    [Fact]
    public async Task CanGetIdinAuthenticationStatus()
    {
        var client = TestHelper.CreateIdinClient();
        var issuer = await client.ListIssuers();

        var trx = await client.Authenticate(new IdinAuthenticationRequest
        {
            ServiceId = Environment.GetEnvironmentVariable("PAY_SERVICEID")!,
            Reference = "Reference",
            IssuerId = issuer.Issuers.First().Key,
            Data = new IdinAuthenticationData
            {
                Address = true,
                DateOfBirth = true,
                Email = true,
                Gender = true,
                Name = true,
                Phone = true,
                IsEighteen = true,
            },
            ReturnUrl = "https://www.google.com"
        });

        var response = await client.GetStatus(trx.TrxId!);

        Assert.NotNull(response);
        Assert.NotNull(response.Request);
        Assert.NotNull(response.Data);
    }
}
