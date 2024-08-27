using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V3.DataTransferObjects;
using PayNlSdk.Sdk.V3.Requests;
using PayNlSdk.Sdk.V3.Requests.Orders;

namespace PayNlSdk.Sdk.V3.Client;

public class PayV3Client : PayV3ClientBase, IPayV3Client
{
	public PayV3Client(string apiSecret, string at, string serviceId, HttpClient? httpClient = null,
		Action<PayRequestLog>? onRequest = default) : base(apiSecret, at, serviceId, httpClient, onRequest)
	{ }

	public new string ServiceId => base.ServiceId;
	public Task<V3Order> CreateOrder(CreateOrderRequest request)
	{
		request.ServiceId ??= ServiceId;
		return _httpClient.PostAsync<V3Order>("orders", request)!;
	}

	public Task<V3Order> GetOrder(string orderId) => _httpClient.GetAsync<V3Order>($"orders/{orderId}/status")!;

	public Task<V3Order> AbortOrder(string orderId) => _httpClient.PatchAsync<V3Order>($"orders/{orderId}/abort")!;

	public Task<V3Order> CaptureOrder(string orderId) => _httpClient.PatchAsync<V3Order>($"orders/{orderId}/capture")!;

	public Task<V3Order> CaptureOrder(string orderId, List<ProductToCapture> productsToCapture) => _httpClient.PatchAsync<V3Order>($"orders/{orderId}/capture", new { products = productsToCapture	})!;

	public Task<V3Order> CaptureOrder(string orderId, int amountCents) => _httpClient.PatchAsync<V3Order>($"orders/{orderId}/capture", new { amount = amountCents })!;

	public Task<V3Order> ApproveOrder(string orderId) => _httpClient.PatchAsync<V3Order>($"orders/{orderId}/approve")!;

	public Task<V3Order> DeclineOrder(string orderId) => _httpClient.PatchAsync<V3Order>($"orders/{orderId}/decline")!;

	public Task<V3Order> VoidOrder(string orderId) => _httpClient.PatchAsync<V3Order>($"orders/{orderId}/void")!;
}
