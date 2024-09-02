using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.Authentication.AuthenticationTokens;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V2.DataTransferModels.TurnoverGroups;

public class TurnoverGroupResponse : TurnoverGroup
{
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("merchant")]
	public Merchant? Merchant { get; set; }

	[JsonPropertyName("bankAccount")]
	public TurnoverGroupBankAccount? BankAccount { get; set; }

	/// <summary>
	/// The creation date time presented in the correct ISO-8601 (a.k.a. ATOM) notation
	/// </summary>
	[JsonPropertyName("createdAt")]
	public DateTime? CreatedAt { get; set; }

	/// <summary>
	/// The reference to an account or token whom created the entity
	/// </summary>
	[JsonPropertyName("createdBy")]
	public string? CreatedBy { get; set; }

	/// <summary>
	/// The modification date time presented in the correct ISO-8601 (a.k.a. ATOM) notation
	/// </summary>
	[JsonPropertyName("modifiedAt")]
	public DateTime? ModifiedAt { get; set; }

	/// <summary>
	/// The reference to an account or token whom modified the entity
	/// </summary>
	[JsonPropertyName("modifiedBy")]
	public string? ModifiedBy { get; set; }

	/// <summary>
	/// The deletion date time presented in the correct ISO-8601 (a.k.a. ATOM) notation. Can be empty (null)
	/// </summary>
	[JsonPropertyName("deletedAt")]
	public DateTime? DeletedAt { get; set; }

	/// <summary>
	/// The reference to an account or token whome deleted the entity
	/// </summary>
	[JsonPropertyName("deletedBy")]
	public string? DeletedBy { get; set; }

	[JsonPropertyName("links")]
	public List<Link>? Links { get; set; }
}
