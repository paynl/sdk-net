using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.DataTransferModels.Transaction;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace PayNlSdk.IntegrationTests;

public class Transactions
{
    [Fact]
    public async Task CreateTransaction()
    {
        var client = TestHelper.CreateClient();

        var trx = await client.CreateTransaction(new CreateTransactionRequest
        {
            Amount = new Amount
            {
                Value = 1000,
            },
            ReturnUrl = "https://demo.pay.nl/complete/",
        });

        Assert.NotNull(trx);
        Assert.NotNull(trx.Id);
        Assert.NotNull(trx.Amount);
        Assert.Equal(1000, trx.Amount.Value);
    }

    [Fact]
    public async Task ViewTransaction()
    {
        var client = TestHelper.CreateClient();

        var trx = await client.CreateTransaction(new CreateTransactionRequest
        {
            Amount = new Amount
            {
                Value = 1000,
            },
            ReturnUrl = "https://demo.pay.nl/complete/",
        });

        var trxInfo = await client.GetTransactionInfo(trx.OrderId!);
        Assert.Equal(trx.Id, trxInfo.Id);
        Assert.Equal(trx.Amount!.Value, trxInfo.Amount!.Value);
        Assert.Equal(trx.CreatedAt, trxInfo.CreatedAt);
    }

    [Fact]
    public async Task CanCancel()
    {
        var client = TestHelper.CreateClient();

        var trx = await client.CreateTransaction(new CreateTransactionRequest
        {
            Amount = new Amount
            {
                Value = 1000,
            },
            ReturnUrl = "https://demo.pay.nl/complete/",
        });

        await client.CancelTransaction(trx.Id!);
        var trxInfo = await client.GetTransactionInfo(trx.Id!);
        Assert.Equal(-90, trxInfo.Status!.Code);
    }

    [Fact(Skip = "Transaction must be paid first")]
    public async Task CanRefund()
    {
        var client = TestHelper.CreateClient();

        var trx = await client.CreateTransaction(new CreateTransactionRequest
        {
            Amount = new Amount
            {
                Value = 2000,
            },
            ReturnUrl = "https://demo.pay.nl/complete/",
        });
        await client.ApproveTransaction(trx.Id!);

        var refundResponse = await client.RefundTransaction(trx.Id!, new RefundTransactionRequest
        {
            Amount = new Amount
            {
                Value = 1000,
            },
        });

        Assert.Equal(1000, refundResponse.Amount!.Value);

        var trxInfo = await client.GetTransactionInfo(trx.Id!);
        Assert.Equal(1000, trxInfo.AmountRefunded!.Value);
    }

    [Fact(Skip = "Required paid transaction")]
    public async Task CanDecline()
    {
        var client = TestHelper.CreateClient();

        var trx = await client.CreateTransaction(new CreateTransactionRequest
        {
            Amount = new Amount
            {
                Value = 2000,
            },
            ReturnUrl = "https://demo.pay.nl/complete/",
        });
        await client.DeclineTransaction(trx.Id!);

        var trxInfo = await client.GetTransactionInfo(trx.Id!);
        Assert.Equal(-90, trxInfo.Status!.Code);
    }
}