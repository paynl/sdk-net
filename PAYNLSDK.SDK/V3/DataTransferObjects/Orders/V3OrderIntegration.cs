using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.DataTransferObjects.Orders;

public class V3OrderIntegration
{
	[JsonPropertyName("test")]
	public bool TestMode { get; set; }

	/// <summary>
	/// ON_THE_MOVE, ECOMMERCE, IN_PERSON, INVOICE, DEBT_COLLECTION, FUNDING, PAYMENT_REQUEST, RECURRING, UNATTENDED, MOTO, PAYOUT
	/// </summary>
	[JsonPropertyName("pointOfInteraction")]
	public string? PointOfInteraction { get; set; }
}
