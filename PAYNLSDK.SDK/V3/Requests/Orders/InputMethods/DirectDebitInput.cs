using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.V3.Requests.Orders.InputMethods;

public class DirectDebitInput : V3InputMethod
{
	[JsonPropertyName("firstName")]
	public string? FirstName { get; set; }

	[JsonPropertyName("lastName")]
	public string? LastName { get; set; }

	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("city")]
	public string? City { get; set; }

	[JsonPropertyName("iban")]
	public string? Iban { get; set; }

	[JsonPropertyName("bic")]
	public string? Bic { get; set; }

	[JsonPropertyName("permissionGiven")]
	public bool PermissionGiven { get; set; }
}
