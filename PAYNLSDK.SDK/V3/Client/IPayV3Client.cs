using PayNlSdk.Sdk.V3.DataTransferObjects;
using PayNlSdk.Sdk.V3.Requests;
using PayNlSdk.Sdk.V3.Requests.Orders;

namespace PayNlSdk.Sdk.V3.Client;

public interface IPayV3Client
{
	public string ServiceId { get; }
	Task<V3Order> CreateOrder(CreateOrderRequest request);
	Task<V3Order> GetOrder(string orderId);
	Task<V3Order> AbortOrder(string orderId);
	Task<V3Order> CaptureOrder(string orderId);
	Task<V3Order> CaptureOrder(string orderId, List<ProductToCapture> productToCapture);
	Task<V3Order> CaptureOrder(string orderId, int amountCents);
	Task<V3Order> ApproveOrder(string orderId);
	Task<V3Order> DeclineOrder(string orderId);
	Task<V3Order> VoidOrder(string orderId);
}
