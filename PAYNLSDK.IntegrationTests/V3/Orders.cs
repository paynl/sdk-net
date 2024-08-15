using PayNlSdk.IntegrationTests.Helpers;
using PayNlSdk.Sdk.V2.DataTransferModels;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;
using PayNlSdk.Sdk.V3.Client;
using PayNlSdk.Sdk.V3.DataTransferObjects.Orders;
using PayNlSdk.Sdk.V3.Requests;
using PayNlSdk.Sdk.V3.Requests.Orders;

namespace PayNlSdk.IntegrationTests.V3;

public class Orders
{
		[Fact]
        public async Task CreateOrder()
        {
	        var (client, trx) = await Setup();
            Assert.NotNull(trx);
            Assert.NotNull(trx.Id);
            Assert.NotNull(trx.Amount);
            Assert.Equal(1000, trx.Amount.Value);
            Assert.Equal(client.ServiceId, trx.ServiceId);
        }

        [Fact]
        public async Task ViewOrder()
        {
	        var (client, trx) = await Setup();
            var trxInfo = await client.GetOrder(trx.OrderId!);
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
	        await Assert.ThrowsAsync<PayNlSdkException>(async () =>
	        {
		        await client.CaptureOrder(trx.Id, 50);
	        });
        }

        [Fact]
        public async Task CanCaptureProducts()
        {
	        var (client, trx) = await Setup();
	        await Assert.ThrowsAsync<PayNlSdkException>(async () =>
	        {
		        await client.CaptureOrder(trx.Id, new List<ProductToCapture>());
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
        public async Task CanApproveORder()
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
		        Amount = new Amount
		        {
			        Value = 1000,
		        },
		        ReturnUrl = "https://demo.pay.nl/complete/",
	        });

	        return (client, trx);
        }
}
