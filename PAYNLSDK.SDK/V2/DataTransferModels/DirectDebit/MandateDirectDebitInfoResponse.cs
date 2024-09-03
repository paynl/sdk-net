using System.Text.Json.Serialization;
using PayNlSdk.Sdk.Utilities;

namespace PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

public class MandateDirectDebitInfoResponse
{
	/// <summary>
	///  The reference ID for this specific directdebit.
	/// </summary>
	[JsonPropertyName("referenceId")]
	public string? ReferenceId { get; set; }

	/// <summary>
	/// The customer's bankaccount.
	/// </summary>
	[JsonPropertyName("bankaccountNumber")]
	public string? BankaccountNumber { get; set; }

	/// <summary>
	///  The customer's name.
	/// </summary>
	[JsonPropertyName("bankaccountHolder")]
	public string? BankaccountHolder { get; set; }

	/// <summary>
	///  The BIC code of the customer's bankaccount.
	/// </summary>
	[JsonPropertyName("bankaccountBic")]
	public string? BankaccountBic { get; set; }

	/// <summary>
	///  The paymentSessionId of the directdebit, useful when you want to retrieve statistics for this directdebit.
	/// </summary>
	[JsonPropertyName("paymentSessionId")]
	public string? PaymentSessionId { get; set; }

	/// <summary>
	///  The amount in cents. For example € 3.50 becomes 350.
	/// </summary>
	[JsonPropertyName("amount")]
	public string? Amount { get; set; }

	/// <summary>
	///  The description of the order.
	/// </summary>
	[JsonPropertyName("description")]
	public string? Description { get; set; }

	/// <summary>
	///  The date the order was sent to the bank.
	/// </summary>
	[JsonPropertyName("sendDate")]
	[JsonConverter(typeof(DateOnlyConverter))]
	public DateTime? SendDate { get; set; }

	/// <summary>
	///  The date the amount was received.
	/// </summary>
	[JsonPropertyName("receiveDate")]
	[JsonConverter(typeof(DateOnlyConverter))]
	public DateTime? ReceiveDate { get; set; }

	/// <summary>
	///  91: Added.
	///	 526: In batch
	///  94: Processed.
	///  97: Processed.
	///  100: Cashed.
	///  103: Deleted.
	///  106: Reversal.
	///  127: Refused by bank.
	///  199: Relist
	/// </summary>
	[JsonPropertyName("statusCode")]
	[JsonConverter(typeof(GenericEnumConverter<MandateStatusCode>))]
	public MandateStatusCode? StatusCode { get; set; }

	[JsonPropertyName("statusName")]
	public string? StatusName { get; set; }

	/// <summary>
	///  109: Administrative reason.
	///  112: Account canceled.
	///  115: Account unknown.
	///  118: No debit authorization provided.
	///  121: Incasso disallowed.
	///  124: Incasso executed twice.
	///  271: Name/number do not match.
	///  274: Account blocked.
	///  277: Selective debit blockade.
	///  280: Account WKA.
	///  286: Reason not supplied.
	///  331: Report wrongful debit
	/// </summary>
	[JsonPropertyName("declineCode")]
	[JsonConverter(typeof(GenericEnumConverter<MandateDeclineCode>))]
	public MandateDeclineCode? DeclineCode { get; set; }

	[JsonPropertyName("declineName")]
	public string? DeclineName { get; set; }

	/// <summary>
	///  The date the amount was declined
	/// </summary>
	[JsonPropertyName("declineDate")]
	[JsonConverter(typeof(DateOnlyConverter))]
	public DateTime? DeclineDate { get; set; }
}
