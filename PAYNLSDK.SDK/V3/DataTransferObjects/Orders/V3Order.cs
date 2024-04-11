using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;
using PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

namespace PayNlSdk.Sdk.V3.DataTransferObjects;

public class V3Order
{
		[JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("serviceId")]
        public string ServiceId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("manualTransferCode")]
        public string ManualTransferCode { get; set; }

        [JsonPropertyName("orderId")]
        public string OrderId { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("customerKey")]
        public string CustomerKey { get; set; }

        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("receipt")]
        public string Receipt { get; set; }

        [JsonPropertyName("integration")]
        public Integration Integration { get; set; }

        [JsonPropertyName("amount")]
        public Amount Amount { get; set; }

        [JsonPropertyName("authorizedAmount")]
        public Amount AuthorizedAmount { get; set; }

        [JsonPropertyName("capturedAmount")]
        public Amount CapturedAmount { get; set; }

        [JsonPropertyName("checkoutData")]
        public V3CheckoutData CheckoutData { get; set; }

        [JsonPropertyName("payments")]
        public List<V3OrderPayment> Payments { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        [JsonPropertyName("modifiedAt")]
        public DateTime? ModifiedAt { get; set; }

        [JsonPropertyName("modifiedBy")]
        public string ModifiedBy { get; set; }

        [JsonPropertyName("expiresAt")]
        public DateTime? ExpiresAt { get; set; }

        [JsonPropertyName("completedAt")]
        public DateTime? CompletedAt { get; set; }
}
