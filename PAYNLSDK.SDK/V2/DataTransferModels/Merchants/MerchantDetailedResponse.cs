using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.ContactMethods;
using PayNlSdk.Sdk.V2.DataTransferModels.Documents;
using PayNlSdk.Sdk.V2.DataTransferModels.Trademarks;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V2.DataTransferModels.Merchants;

public class MerchantDetailedResponse
{
	[JsonPropertyName("code")]
	public string? Code { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("publicName")]
	public string? PublicName { get; set; }

	[JsonPropertyName("status")]
	public string? Status { get; set; }

	[JsonPropertyName("payoutStatus")]
	public string? PayoutStatus { get; set; }

	[JsonPropertyName("coc")]
	public string? Coc { get; set; }

	[JsonPropertyName("vat")]
	public string? Vat { get; set; }

	[JsonPropertyName("companyTypeId")]
	public string? CompanyTypeId { get; set; }

	[JsonPropertyName("countryCode")]
	public string? CountryCode { get; set; }

	[JsonPropertyName("contractLanguage")]
	public string? ContractLanguage { get; set; }

	[JsonPropertyName("contractPackage")]
	public string? ContractPackage { get; set; }

	[JsonPropertyName("website")]
	public string? Website { get; set; }

	[JsonPropertyName("category")]
	public Category? Categories { get; set; }

	[JsonPropertyName("integration")]
	public Category? Integration { get; set; }

	[JsonPropertyName("clearingAccounts")]
	public List<ClearingAccount>? ClearingAccounts { get; set; }

	[JsonPropertyName("postalAddress")]
	public Address? PostalAddress { get; set; }

	[JsonPropertyName("visitAddress")]
	public Address? VisitAddress { get; set; }

	[JsonPropertyName("contactMethods")]
	public List<ContactMethodResponse>? ContactMethods { get; set; }

	[JsonPropertyName("authenticationTokens")]
	public List<AuthenticationToken>? AuthenticationTokens { get; set; }

	[JsonPropertyName("trademarks")]
	public List<TrademarkResponse>? Trademarks { get; set; }

	[JsonPropertyName("documents")]
	public List<Document>? Documents { get; set; }

	[JsonPropertyName("partner")]
	public List<MerchantPartner>? Partner { get; set; }

	[JsonPropertyName("createdAt")]
	public DateTime? CreatedAt { get; set; }

	[JsonPropertyName("createdBy")]
	public string? CreatedBy { get; set; }

	[JsonPropertyName("acceptedAt")]
	public DateTime? AcceptedAt { get; set; }

	[JsonPropertyName("suspendedAt")]
	public DateTime? SuspendedAt { get; set; }

	[JsonPropertyName("suspendedBy")]
	public string? SuspendedBy { get; set; }

	[JsonPropertyName("modifiedAt")]
	public DateTime? ModifiedAt { get; set; }

	[JsonPropertyName("modifiedBy")]
	public string? ModifiedBy { get; set; }

	[JsonPropertyName("deletedAt")]
	public DateTime? DeletedAt { get; set; }

	[JsonPropertyName("deletedBy")]
	public string? DeletedBy { get; set; }

	[JsonPropertyName("reviewedAt")]
	public DateTime? ReviewedAt { get; set; }

	[JsonPropertyName("nextReviewDate")]
	public DateTime? NextReviewDate { get; set; }

	[JsonPropertyName("_links")]
	public List<Link>? Links { get; set; }
}
