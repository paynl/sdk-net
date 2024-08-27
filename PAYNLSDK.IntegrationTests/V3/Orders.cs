using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;
using PayNlSdk.Sdk.V3.Client;
using PayNlSdk.Sdk.V3.DataTransferObjects;
using PayNlSdk.Sdk.V3.DataTransferObjects.Orders;
using PayNlSdk.Sdk.V3.Requests;
using PayNlSdk.Sdk.V3.Requests.Orders;
using PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;
using Xunit.Abstractions;

namespace PayNlSdk.IntegrationTests.V3;

public class Orders
{
	private readonly ITestOutputHelper _testOutputHelper;

	public Orders(ITestOutputHelper testOutputHelper)
	{
		_testOutputHelper = testOutputHelper;
	}

	[Fact]
	public async Task CreateOrder()
	{
		var (client, trx) = await Setup();
		Assert.NotNull(trx);
		Assert.NotNull(trx.Id);
		Assert.NotNull(trx.Amount);
		Assert.Equal(25000, trx.Amount.Value);
		Assert.Equal(client.ServiceId, trx.ServiceId);
	}

	[Fact]
	public async Task ViewOrder()
	{
		var (client, trx) = await Setup();
		var trxInfo = await client.GetOrder(trx.OrderId);
		Assert.Equal(trx.Id, trxInfo.Id);
		Assert.Equal(trx.Amount!.Value, trxInfo.Amount!.Value);
		Assert.Equal(trx.CreatedAt, trxInfo.CreatedAt);
	}

	[Fact]
	public async Task CanCaptureOrder()
	{
		var (client, trx) = await Setup();
		await Assert.ThrowsAsync<PayNlSdkException>(async () =>
		{
			await client.CaptureOrder(trx.Id!);
		});
	}

	[Fact]
	public async Task CanCaptureAmount()
	{
		var (client, trx) = await Setup();

		// Pay trx using CC or BNPL. As these are the only methods for which we can capture.
		_testOutputHelper.WriteLine($"Manual action: pay using CC or BNPL {trx.Links.Last().Value}");
		await Task.Delay(TimeSpan.FromMinutes(2));
		var res = await client.CaptureOrder(trx.Id, 50);
		_testOutputHelper.WriteLine("Captured amount: " + res.CapturedAmount!.Value);
	}

	[Fact]
	public async Task CanCaptureProducts()
	{
		var (client, trx) = await Setup();
		await Assert.ThrowsAsync<PayNlSdkException>(async () =>
		{
			var res = await client.CaptureOrder(trx.Id, new List<ProductToCapture>() { new ProductToCapture() { Id = "Test123", Quantity = 1 } });
			_testOutputHelper.WriteLine("Captured amount: " + res.CapturedAmount!.Value);
		});
	}

	[Fact]
	public async Task CanVoidOrder()
	{
		var (client, trx) = await Setup();
		await Assert.ThrowsAsync<PayNlSdkException>(async () =>
		{
			await client.VoidOrder(trx.Id);
		});
	}

	[Fact]
	public async Task CanAbortOrder()
	{
		var (client, trx) = await Setup();
		await client.AbortOrder(trx.Id!);
		var trxInfo = await client.GetOrder(trx.Id!);
		Assert.Equal(-90, trxInfo.Status!.Code);
	}

	[Fact]
	public async Task CanApproveOrder()
	{
		var (client, trx) = await Setup();
		await Assert.ThrowsAsync<PayNlSdkException>(async () =>
		{
			await client.ApproveOrder(trx.Id);
		});
	}

	[Fact]
	public async Task CanDeclineOrder()
	{
		var (client, trx) = await Setup();
		await Assert.ThrowsAsync<PayNlSdkException>(async () =>
		{
			await client.DeclineOrder(trx.Id);
		});
	}

	private async Task<(IPayV3Client client, V3Order order)> Setup()
	{
		var client = TestHelper.CreateClientV3();
		var trx = await client.CreateOrder(new CreateOrderRequest
		{
			Integration = new Integration()
			{
				TestMode = true, // Test mode
			},
			PaymentMethod = new V3PaymentMethod()
			{
				Id = 1717, // Klarna
				Input = new KlarnaInput()
				{
					CountryCode = "nl"
				}
			},
			Amount = new Amount
			{
				Value = 25000, // Amount in cents
			},
			ReturnUrl = "https://demo.pay.nl/complete/",
			Customer = new V3Customer() // Commented out details, as klarna validates these to be real, even in test mode
			{
				// Company = new V3Company()
				// {
				// 	Country = "NL",
				// 	Name = "Test Company",
				// 	CocNumber = "123456789",
				// 	VatNumber = "NL85234567890",
				// },
				// Email = "test@example.com",
				// Phone = "+31 6123456789",
				// Gender = "M",
				// Firstname = "John",
				// Lastname = "Doe",
				Locale = "nl_NL",
				// DateOfBirth = DateTime.UtcNow.AddYears(-25),
				// IpAddress = "127.0.0.1",
				// Reference = "Reference"
			},
			Reference = "Reference",
			Description = "Test Order",
			ExchangeUrl = "https://demo.pay.nl/exchange/",
			Expire = DateTime.UtcNow.AddMinutes(15),
			ServiceId = client.ServiceId,
			Notification = new V3Notification()
			{
				Recipient = "test@example.com",
				Type = "push"
			},
			Order = new V3OrderInput()
			{
				Products = new List<V3CreateOrderProduct>()
				{
					new V3CreateOrderProduct()
					{
						Type = "SHIPPING",
						Quantity = 1,
						Description = "Shipping container fee",
						Id = "Test123",
						Price = new Amount()
						{
							Value = 50,
							Currency = "USD"
						},
						VatPercentage = 21
					}
				},
				CountryCode = "NL",
				// DeliveryAddress = new V3CreateOrderAddress()
				// {
				// 	Street = "Test Street",
				// 	ZipCode = "1234AB",
				// 	Country = "NL",
				// 	Region = "Noord-Holland",
				// 	FirstName = "John",
				// 	LastName = "Doe",
				// 	StreetNumber = "4",
				// 	StreetNumberExtension = "B"
				// },
				// InvoiceAddress = new V3CreateOrderAddress()
				// {
				// 	Street = "Test Street",
				// 	ZipCode = "1234AB",
				// 	Country = "NL",
				// 	Region = "Noord-Holland",
				// 	FirstName = "John",
				// 	LastName = "Doe",
				// 	StreetNumber = "4",
				// 	StreetNumberExtension = "B"
				// },
				DeliveryDate = DateTime.UtcNow.AddDays(-19),
				InvoiceDate = DateTime.UtcNow.AddDays(1),
			},
			Stats = new Stats()
			{
				Extra1 = "extra1",
				Extra2 = "extra2",
				Extra3 = "extra3",
				DomainId = "domainId",
				Info = "Info",
				Object = "object",
				Tool = "tool"
			},

			TransferData = new Dictionary<string, string>()
			{
				{ "transferDataKey1", "transferDataValue1" },
				{ "transferDataKey2", "transferDataValue2" }
			}
		});
		return (client, trx);
	}
}
