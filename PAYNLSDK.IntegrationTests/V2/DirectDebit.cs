using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.IntegrationTests.V2;

public class DirectDebit
{
    [Fact(Skip = "Needs order id")]
    public async Task CreateDirectDebit()
    {
        var client = TestHelper.CreateClientV2();

        var dd = await client.CreateDirectDebit("IL-####-####-####", new CreateDirectDebitRequest
        {
            Amount = new Amount
            {
                Value = 1000,
            },
            Description = "desc",
        });

        Assert.NotNull(dd);
        Assert.NotNull(dd.Mandate);
    }
}