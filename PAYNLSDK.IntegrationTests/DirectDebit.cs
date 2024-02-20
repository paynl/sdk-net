using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.DataTransferModels.DirectDebit;
using PayNlSdk.Sdk.DataTransferModels.Transaction;


namespace PayNlSdk.IntegrationTests;

public class DirectDebit
{
    [Fact(Skip = "Needs order id")]
    public async Task CreateDirectDebit()
    {
        var client = TestHelper.CreateClient();

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