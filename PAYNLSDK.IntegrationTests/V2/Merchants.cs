using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels.Merchants;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

#pragma warning disable CS8604 // Possible null reference argument.

namespace PayNlSdk.IntegrationTests.V2;

public class Merchants
{
    [Fact]
    public async Task CreateMerchant()
    {
        var client = TestHelper.CreateClientV2();
        var pkgs = await client.GetAllPackages();
        Assert.NotNull(pkgs);
        Assert.NotNull(pkgs.Packages);
        var merchant = await client.CreateMerchant(new()
        {
            Merchant = new CreateMerchantModel
            {
                Name = "merchant!",
                Coc = "12345678",
                CompanyTypeId = "1",
                CountryCode = "NL",
                ContractLanguage = "nl_NL",
                VisitAddress = new Address
                {
                    StreetName = "street", StreetNumber = "1", ZipCode = "1234AB", City = "city", CountryCode = "NL"
                },
                AuthenticationTokens = new List<AuthenticationToken>
                {
                    new AuthenticationToken
                    {
                        Description = "foo",
                        Authorisation = "all",
                    },
                },
                Persons = new List<Person>
                {
                    new Person
                    {
                        FirstName = "Mister",
                        LastName = "Rogers",
                        Email = "MisterRogers@testmail.com",
                        Platform = new Platform
                        {
                            Authorisation = "all",
                        }
                    }
                }
            },
            Partner = new CreateMerchantPartnerModel
            {
                ConnectionType = "ALLIANCE",
                ReferralProfileCode = pkgs.Packages.First().Code,
            }
        });

        Assert.NotNull(merchant.Merchant);

        await client.DeleteMerchant(merchant.Merchant.Code);
    }

    [Fact]
    public async Task GetMerchants()
    {
        var client = TestHelper.CreateClientV2();

        var merchants = await client.ListMerchants();
        Assert.NotNull(merchants);
        Assert.NotEmpty(merchants.Merchants);
        Assert.True(merchants.Total > 0);
        Assert.Equal(merchants.Total, merchants.Merchants.Count());

        var merchant = await client.GetMerchant(merchants.Merchants.First().Code!);
        Assert.NotNull(merchant);
        Assert.Equal(merchants.Merchants.First().Code, merchant.Code);
    }

    [Fact]
    public async Task GetMerchant()
    {
	    var client = TestHelper.CreateClientV2();

	    var merchants = await client.GetMerchant("M-3421-2120");
	    Assert.NotNull(merchants);
	    Assert.NotNull(merchants.Code);
    }

    [Fact]
    public async Task GetMerchantDetailed()
    {
	    var client = TestHelper.CreateClientV2();

	    var merchants = await client.GetMerchantDetailed("M-3421-2120");
	    Assert.NotNull(merchants);
	    Assert.NotNull(merchants.Code);
    }

    [Fact(Skip="First need referral Profile Code")]
    public async Task UpdateMerchantPackage()
    {
	    var client = TestHelper.CreateClientV2();
	    await client.UpdateMerchantPackage("M-3421-2120", "");
    }
}
