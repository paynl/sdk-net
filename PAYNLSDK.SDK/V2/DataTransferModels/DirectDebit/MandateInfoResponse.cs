using System.Text.Json.Serialization;
using PayNlSdk.Sdk.Utilities;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public class MandateInfoResponse : Stats
{
	/// <summary>
	/// The mandate ID for the related directdebit order.
	/// </summary>
	[JsonPropertyName("mandateId")]
	public string? MandateId { get; set; }

	/// <summary>
	/// The customer's bankaccount.
	/// </summary>
	[JsonPropertyName("type")]
	public string? Type { get; set; }

	/// <summary>
	///	The customer's bankaccount.
	/// </summary>
	[JsonPropertyName("bankaccountNumber")]
	public string? BankaccountNumber { get; set; }

	/// <summary>
	/// The customer's name.
	/// </summary>
	[JsonPropertyName("bankaccounOwner")]
	public string? BankaccountOwner { get; set; }

	/// <summary>
	/// The BIC code of the customer's bankaccount.
	/// </summary>
	[JsonPropertyName("bankaccountBic")]
	public string? BankaccountBic { get; set; }

	/// <summary>
	/// The latest amount in cents. For example € 3.50 becomes 350.
	/// </summary>
	[JsonPropertyName("amount")]
	public string? Amount { get; set; }

	/// <summary>
	/// The latest description of the order.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	/// If intervalValue is 2 and intervalPeriod is 1 than process the directdebit every two weeks.
	/// </summary>
	[JsonPropertyName("intervalValue")]
	public string? IntervalValue { get; set; }

	/// <summary>
	///  1 : Week, 2 : Month, 3: Quarter, 4 : Half year, 5:Year, 6: Day, 7: Manual
	/// </summary>
	[JsonPropertyName("intervalPeriod")]
	[JsonConverter(typeof(GenericEnumConverter<MandateIntervalPeriod>))]
	public MandateIntervalPeriod? IntervalPeriod { get; set; }

	/// <summary>
	/// The number of times this order can be executed in the future.
	/// </summary>
	[JsonPropertyName("intervalQuantity")]
	public string? IntervalQuantity { get; set; }

	/// <summary>
	///  State of the order. Options are: first, active, last, deleted, single
	/// </summary>
	[JsonPropertyName("state")]
	public string? State { get; set; }

	/// <summary>
	///  IP address of the customer
	/// </summary>
	[JsonPropertyName("ipAddress")]
	public string? IpAddress { get; set; }

	/// <summary>
	///  Emailaddress of the customer
	/// </summary>
	[JsonPropertyName("email")]
	public string? Email { get; set; }
}
