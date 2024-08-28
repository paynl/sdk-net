namespace PayNlSdk.Sdk.Utilities;

public enum DateFilter
{
	/// <summary>
	/// Get results that on the given date.
	/// </summary>
	Equal,
	/// <summary>
	/// Get results that are after the given date.
	/// </summary>
	GreaterThan,
	/// <summary>
	/// Get results that are after or on the given date.
	/// </summary>
	GreaterThanEqual,
	/// <summary>
	/// Get results that are before the given date.
	/// </summary>
	LessThan,
	/// <summary>
	/// Get results that are before or on the given date.
	/// </summary>
	LessThanEqual
}

public enum StringFilter
{
	/// <summary>
	/// Get results that equal the given value.
	/// </summary>
	Equal,
	/// <summary>
	/// Get results that do not equal the given value.
	/// </summary>
	NotEqual,
}

internal static class FilterExtension
{
	internal static string GetValue(this DateFilter filter)
	{
		return filter switch
		{
			DateFilter.Equal => "[eq]",
			DateFilter.GreaterThan => "[gt]",
			DateFilter.GreaterThanEqual => "[gte]",
			DateFilter.LessThan => "[lt]",
			DateFilter.LessThanEqual => "[lte]",
			_ => throw new ArgumentOutOfRangeException(nameof(filter), filter, null)
		};
	}

	internal static string GetValue(this StringFilter filter)
	{
		return filter switch
		{
			StringFilter.Equal => "[eq]",
			StringFilter.NotEqual => "[neq]",
			_ => throw new ArgumentOutOfRangeException(nameof(filter), filter, null)
		};
	}
}
