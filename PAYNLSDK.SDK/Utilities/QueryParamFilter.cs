using System.Web;

namespace PayNlSdk.Sdk.Utilities;

public abstract class QueryParamFilter<T> where T : QueryParamFilter<T>
{
	protected readonly Dictionary<string, string> _filters = new();

	/// <summary>
	/// Limit the returned records.
	/// If not supplied we will default to 100 records
	/// </summary>
	public T WithLimit(int limit)
	{
		_filters["limit"] = limit.ToString();
		return (T)this;
	}

	/// <summary>
	/// Indicate which page you want in your result set.
	/// If not supplied we will default to page 1.
	/// </summary>
	public T WithPage(int page)
	{
		_filters["page"] = page.ToString();
		return (T)this;
	}

	/// <summary>
	/// Indicate in which period the transactions are done.
	/// </summary>
	/// <param name="filter">Filter operator.</param>
	/// <param name="date">Date to apply operator on.</param>
	public T WithDate(DateFilter filter, DateTime date)
	{
		_filters[$"date{filter.GetValue()}"] = date.ToString("yyyy-MM-dd");
		return (T)this;
	}

	/// <summary>
	/// Indicate for which period you want to retrieve the clearing lines.
	/// </summary>
	/// <param name="filter">Filter operator.</param>
	/// <param name="date">Date to apply operator on.</param>
	public T WithProcessedDate(DateFilter filter, DateTime date)
	{
		_filters[$"processedDate{filter.GetValue()}"] = date.ToString("yyyy-MM-dd");
		return (T)this;
	}

	/// <summary>
	/// If you are a partner you can indicate for which merchants you want to retrieve the clearing lines.
	/// If you do not supply a merchant we will return the clearing lines for all your merchants.
	/// </summary>
	/// <param name="filter">Filter operator.</param>
	/// <param name="merchantCode"></param>
	public T WithMerchant(StringFilter filter, string merchantCode)
	{
		_filters[$"merchant{filter.GetValue()}"] = merchantCode;
		return (T)this;
	}

	/// <summary>
	/// You can indicate for which turnover group you want to retrieve the clearing lines.
	/// If not supplied we will return the clearing lines for all turnover groups.
	/// </summary>
	public T WithTurnoverGroup(string turnoverGroupId)
	{
		_filters["turnoverGroup[eq]"] = turnoverGroupId;
		return (T)this;
	}

	/// <summary>
	/// Builds the query string using the applied filters.
	/// </summary>
	/// <returns>Query string</returns>
	protected internal string Build()
	{
		var query = HttpUtility.ParseQueryString(string.Empty);
		foreach (var filter in _filters)
		{
			query[filter.Key] = filter.Value;
		}

		var queryString = query.ToString();
		return string.IsNullOrEmpty(queryString) ? "" : $"?{queryString}";
	}
}
