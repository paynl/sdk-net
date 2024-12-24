using System.Text;
using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V2.Idin.Requests;
using PayNlSdk.Sdk.V2.Idin.Responses;

#pragma warning disable CS8604 // Possible null reference argument.

namespace PayNlSdk.IntegrationTests.V2;

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

    [Fact]
    public async Task CanHandle404()
    {
	    var content = """
	                     {
	                        "request": {
	                           "result": "0",
	                           "errorId": "PAY-9114",
	                           "errorMessage": "Transaction not found"
	                        },
	                        "data": ""
	                     }
	                  """;

	    var idinResponse = await Json.DeserializeAsync<IdinAuthenticationStatusResponse>(new MemoryStream(Encoding.UTF8.GetBytes(content)));
		Assert.NotNull(idinResponse);
		Assert.Null(idinResponse.Data);
    }

    [Fact]
    public async Task CanHandleSuccess()
    {
	    var content = """
	                  {
	                      "request": {
	                         "result": "1",
	                         "errorId": "",
	                         "errorMessage": ""
	                      },
	                      "data": {
	                        "state": "Success",
	                        "statusMessage": "",
	                        "reference": "a671d69c-3214-4ad7-fda-123",
	                        "id": "NLRBO123",
	                        "name": {
	                           "prefLastName": "Jhon - Doe",
	                           "prefLastNamePrefix": "",
	                           "legalLastName": "Doe",
	                           "legalLastNamePrefix": "",
	                           "partnerLastName": "",
	                           "partnerLastNamePrefix": "",
	                           "initials": "JD",
	                           "firstName": ""
	                        },
	                        "address": {
	                           "street": "Veestraat",
	                           "houseNo": "108",
	                           "houseNoSuf": "",
	                           "postalCode": "5555PA",
	                           "city": "Helmond",
	                           "country": "NL",
	                           "addressExtra": "",
	                           "intAddressLine": ""
	                        },
	                        "isEighteen": "",
	                        "dateOfBirth": "1999-09-20",
	                        "gender": "female",
	                        "phone": "+31648212345",
	                        "email": "test@mail.com"
	                     }
	                  }
	                  """;

	    var idinResponse = await Json.DeserializeAsync<IdinAuthenticationStatusResponse>(new MemoryStream(Encoding.UTF8.GetBytes(content)));
	    Assert.NotNull(idinResponse);
	    Assert.NotNull(idinResponse.Data);
	    Assert.NotNull(idinResponse.Data.Address);
	    Assert.NotNull(idinResponse.Data.Name);
    }
}
