namespace PayNlSdk.Sdk.Utilities;

/// <summary>
/// Used to build the query parameters for ClearingLines endpoint.
/// </summary>
public class ClearingLineFilter : QueryParamFilter<ClearingLineFilter>
{
	/// <summary>
	/// You can indicate which lineType you want to retrieve.
	/// See for more information the BillingLineTypes API (https://developer.pay.nl/reference/get_billinglinetypes)
	/// </summary>
	public ClearingLineFilter WithClearingLineType(int lineTypeId)
	{
		_filters["clearingLineType[eq]"] = lineTypeId.ToString();
		return this;
	}

	/// <summary>
	/// A clearing line is available on a clearing.
	/// By providing a clearing ID you will only retrieve clearing lines for that clearing.
	/// </summary>
	public ClearingLineFilter WithClearingId(string clearingId)
	{
		_filters["clearingID[eq]"] = clearingId;
		return this;
	}

	/// <summary>
	/// A clearing line has a state.
	/// By providing a state you will only retrieve clearing lines in that state.
	/// </summary>
	public ClearingLineFilter WithState(ClearingState state)
	{
		_filters["state[eq]"] = state.ToString().ToUpper();
		return this;
	}
}
