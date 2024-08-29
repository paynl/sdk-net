using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels;
using PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.IntegrationTests.V2;

public class DirectDebit
{
	[Fact]
	public async Task CreateDirectDebitOrderSingle()
	{
		var client = TestHelper.CreateClientV2();
		var ddo = await client.CreateDirectDebitOrder(new CreateDirectDebitOrderRequest
		{
			ServiceId = Environment.GetEnvironmentVariable("PAY_SERVICEID"),
			Amount = new Amount
			{
				Value = 1,
			},
			Customer = new Customer
			{
				BankAccount = new PaymentBankAccount
				{
					Iban = "NL42INGB0000000000",
					Bic = "INGBNL2A",
					Owner = "Test Owner"
				}
			}
		});

		Assert.NotNull(ddo);
		Assert.NotNull(ddo.Mandate?.Id);
		Assert.True(ddo.Mandate?.Type == "single");
	}

	[Fact]
	public async Task CreateDirectDebitOrderRecurring()
	{
		var client = TestHelper.CreateClientV2();
		var ddo = await client.CreateDirectDebitOrder(new CreateDirectDebitOrderRequest
		{
			ServiceId = Environment.GetEnvironmentVariable("PAY_SERVICEID"),
			ProcessDate = new DateTime(2024, 9,2),
			Amount = new Amount
			{
				Value = 1,
			},
			Customer = new Customer
			{
				BankAccount = new PaymentBankAccount
				{
					Iban = "NL42INGB0000000000",
					Bic = "INGBNL2A",
					Owner = "Test"
				}
			},
			Interval = new Interval()
			{
				Period = "year",
				Quantity = 1,
				Value = 1
			}
		});

		Assert.NotNull(ddo);
		Assert.NotNull(ddo.Mandate?.Id);
		Assert.True(ddo.Mandate?.Type == "recurring");
	}

	[Fact]
	public async Task GetDirectDebit()
	{
		var client = TestHelper.CreateClientV2();
		var order = await client.GetDirectDebit("IO-9227-5458-6252");

		Assert.NotNull(order);
		Assert.NotNull(order.Mandate?.Id);
		Assert.NotNull(order.Mandate?.Amount);
	}

	[Fact]
	public async Task PatchDirectDebit()
	{
		var client = TestHelper.CreateClientV2();
		var ddo = await client.UpdateDirectDebit("IO-9372-1453-6142",new UpdateDirectDebitRequest
		{
			Amount = new Amount
			{
				Value = 2,
			},
			Customer = new Customer
			{
				BankAccount = new PaymentBankAccount
				{
					Iban = "NL42INGB0000000000",
					Bic = "INGBNL2A",
					Owner = "Test "
				}
			}
		});

		Assert.NotNull(ddo);
		Assert.NotNull(ddo.Mandate?.Id);
		Assert.Equal(ddo.Mandate.Amount?.Value, 2);
	}

	[Fact]
	public async Task DeleteDirectDebit()
	{
		var client = TestHelper.CreateClientV2();
		// Should not throw any exception on first delete
		await client.DeleteDirectDebit("IO-9372-1453-6142");
		// Should throw 404 on second delete
		await Assert.ThrowsAsync<PayNlSdkException>(() => client.DeleteDirectDebit("IO-9372-1453-6142"));
	}

    [Fact]
    public async Task CreateDirectDebit()
    {
        var client = TestHelper.CreateClientV2();

        var dd = await client.CreateDirectDebit("IO-9227-5458-6252", new CreateDirectDebitRequest
        {
            Amount = new Amount
            {
                Value = 1,
            },
            Description = "desc",
        });

        Assert.NotNull(dd);
        Assert.NotNull(dd.Mandate);
    }


    [Fact]
    public async Task CreateMandate()
    {
	    var client = TestHelper.CreateClientV2();
	    var mandate = await client.CreateMandate(new CreateMandateRequest
	    {
		    ServiceId = Environment.GetEnvironmentVariable("PAY_SERVICEID")!,
		    Amount= 1,
		    Bankaccountholder = Environment.GetEnvironmentVariable("PAY_BANKACCOUNTHOLDER")!,
		    ProcessDate = DateTime.Now.ToString("dd-MM-yyyy"),
		    Description = "Test run",
		    BankaccountNumber = Environment.GetEnvironmentVariable("PAY_BANKACCOUNTNUMBER")!
	    });

	    Assert.NotNull(mandate.MandateId);
    }

    [Fact]
    public async Task CreateFlexibleDirectDebit()
    {
	    var client = TestHelper.CreateClientV2();
	    var test = await client.CreateFlexibleDirectDebit(new FlexibleDirectDebitRequest
	    {
		    MandateId = "IO-2274-8936-8111",
		    Amount = 1,
		    ProcessDate = DateTime.Now.ToString("dd-MM-yyyy"),
		    Description = "Test run",
		    Last = false,
	    });

	    Assert.NotNull(test);
    }
}
