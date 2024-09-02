namespace PayNlSdk.Sdk.Utilities.QueryFilterExtensions;

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
