namespace PayNlSdk.Sdk.Utilities;

public class InvoiceLineFilter : QueryParamFilter<InvoiceLineFilter>
{
	/// <summary>
	/// You can indicate which lineType you want to retrieve.
	/// See for more information the BillingLineTypes API (https://developer.pay.nl/reference/get_billinglinetypes)
	/// </summary>
	public InvoiceLineFilter WithBillingLineType(int lineTypeId)
	{
		_filters["billingLineType[eq]"] = lineTypeId.ToString();
		return this;
	}

	/// <summary>
	/// An invoice line is available on a invoice.
	/// By providing an invoice ID you will only retrieve invoice lines for that invoice
	/// </summary>
	public InvoiceLineFilter WithInvoiceId(string lineTypeId)
	{
		_filters["invoiceID[eq]"] = lineTypeId;
		return this;
	}

	/// <summary>
	/// An invoice line has a state.
	/// By providing a state you will only retrieve invoice lines in that state.
	/// </summary>
	public InvoiceLineFilter WithState(InvoiceState state)
	{
		_filters["state[eq]"] = state.ToString().ToUpper();
		return this;
	}

	/// <summary>
	/// An invoice line has a state.
	/// By providing a state you will only retrieve invoice lines in that state.
	/// </summary>
	public InvoiceLineFilter WithType(InvoiceType type)
	{
		_filters["type[eq]"] = type.ToString().ToUpper();
		return this;
	}
}
