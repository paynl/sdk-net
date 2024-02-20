using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.DataTransferModels.Trademarks;


namespace PayNlSdk.IntegrationTests;

public class Trademarks
{
    [Fact(Skip = "No rights to access this endpoint")]
    public async Task CanGetTrademarks()
    {
        var client = TestHelper.CreateClient();

        var trademarks = await client.GetAllTrademarks();

        Assert.NotNull(trademarks);
        Assert.NotEmpty(trademarks.Trademarks!);
        Assert.True(trademarks.Total > 0);
        Assert.Equal(trademarks.Total, trademarks.Trademarks!.Count());
    }

    [Fact(Skip = "No rights to access this endpoint")]
    public async Task CanGetTrademark()
    {
        var client = TestHelper.CreateClient();

        var trademarks = await client.GetAllTrademarks();
        var trademark = await client.GetTrademark(trademarks.Trademarks!.First().Code!);

        Assert.NotNull(trademark);
        Assert.Equal(trademarks.Trademarks!.First().Code, trademark.Code);
    }

    [Fact(Skip = "No rights to access this endpoint")]
    public async Task CanCreateTrademark()
    {
        var client = TestHelper.CreateClient();

        var created = await client.CreateTrademark(new CreateTrademarkRequest
        {
            Name = "Test Trademark",
        });

        var trademark = await client.GetTrademark(created.Code!);

        Assert.Equal(created, trademark);
    }

    [Fact(Skip = "No rights to access this endpoint")]
    public async Task CanSuspendAndUnsuspend()
    {
        var client = TestHelper.CreateClient();

        var created = await client.CreateTrademark(new CreateTrademarkRequest
        {
            Name = "Test Trademark",
        });

        await client.SuspendTrademark(created.Code!);
        var trademark = await client.GetTrademark(created.Code!);

        Assert.Equal("SUSPENDED", trademark.Status);

        await client.UnsuspendTrademark(created.Code!);
        trademark = await client.GetTrademark(created.Code!);
        Assert.Equal("ACTIVE", trademark.Status);
    }
}