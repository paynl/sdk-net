namespace PayNlSdk.Sdk.Utilities.QueryFilterExtensions;

public enum DateFilter
{
	/// <summary>
	/// Get results that on the given date.
	/// </summary>
	Equal = 1,
	/// <summary>
	/// Get results that are after the given date.
	/// </summary>
	GreaterThan = 2,
	/// <summary>
	/// Get results that are after or on the given date.
	/// </summary>
	GreaterThanEqual = 3,
	/// <summary>
	/// Get results that are before the given date.
	/// </summary>
	LessThan = 4,
	/// <summary>
	/// Get results that are before or on the given date.
	/// </summary>
	LessThanEqual = 5
}
