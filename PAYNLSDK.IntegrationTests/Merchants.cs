using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.DataTransferModels.Merchants;
using PayNlSdk.Sdk.DataTransferModels.Transaction;


#pragma warning disable CS8604 // Possible null reference argument.

namespace PayNlSdk.IntegrationTests;

public class Merchants
{
    [Fact(Skip = "No rights to access this endpoint")]
    public async Task CreateMerchant()
    {
        var client = TestHelper.CreateClient();
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

        Assert.NotNull(merchant);
    }

    [Fact]
    public async Task GetMerchants()
    {
        var client = TestHelper.CreateClient();

        var merchants = await client.ListMerchants();
        Assert.NotNull(merchants);
        Assert.NotEmpty(merchants.Merchants);
        Assert.True(merchants.Total > 0);
        Assert.Equal(merchants.Total, merchants.Merchants.Count());

        var merchant = await client.GetMerchant(merchants.Merchants.First().Code!);
        Assert.NotNull(merchant);
        Assert.Equal(merchants.Merchants.First().Code, merchant.Code);
    }
}