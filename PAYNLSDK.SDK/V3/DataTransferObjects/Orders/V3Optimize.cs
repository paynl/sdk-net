using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3Optimize
{
	[JsonPropertyName("collectorAccount")]
    public V3CollectorAccount? CollectorAccount { get; set; }
	[JsonPropertyName("collectorCompany")]
    public V3CollectorCompany? CollectorCompany { get; set; }
	[JsonPropertyName("flow")]
    public string Flow { get; set; }
	[JsonPropertyName("shippingAddress")]
    public bool ShippingAddress { get; set; }
	[JsonPropertyName("billingAddress")]
    public bool BillingAddress { get; set; }
	[JsonPropertyName("contactDetails")]
    public bool ContactDetails { get; set; }
    [JsonPropertyName("mcc")]
    public string Mcc { get; set; }
}
