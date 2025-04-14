using System.Text.Json;
using Newtonsoft.Json;
using PayNlSdk.Sdk.V2.DataTransferModels.Transaction;

namespace PayNlSdk.IntegrationTests.V2;

public class Refunds
{
	[Fact]
	public void RefundGetsDeserialized()
	{
		var body = @"
{
  ""orderId"": ""1661180545X1ca9c"",
  ""transactionId"": ""EX-5431-7835-5460"",
  ""description"": ""We have refunded € 0,10 by refunding IBAN bankaccount (NL16RABO1822913977) with € 0,10"",
  ""processDate"": ""2022-12-01T14:37:58+01:00"",
  ""amount"": {
    ""value"": 1000,
    ""currency"": ""EUR""
  },
  ""amountRefunded"": {
    ""value"": 10,
    ""currency"": ""EUR""
  },
  ""refundedTransactions"": [
    {
      ""amountRefunded"": {
        ""value"": 10,
        ""currency"": ""EUR""
      },
      ""refund"": {
        ""id"": ""RF-1234-1234-1234-1234""
      },
      ""createdAt"": ""2022-12-01T14:37:58+01:00"",
      ""createdBy"": ""AT-1234-4321""
    }
  ],
  ""createdAt"": ""2022-12-01T14:37:58+01:00"",
  ""createdBy"": ""AT-1234-4321"",
  ""_links"": [
    {
      ""href"": ""/transactions/EX-5431-7835-5460/refund"",
      ""rel"": ""self"",
      ""type"": ""PATCH""
    },
    {
      ""href"": ""/transactions/EX-5431-7835-5460"",
      ""rel"": ""details"",
      ""type"": ""GET""
    }
  ]
}";
		var response = JsonConvert.DeserializeObject<SuccessfulRefundResponse>(body);
		Assert.NotNull(response);
		Assert.Equal("1661180545X1ca9c", response.OrderId);
		Assert.Equal(DateTime.Parse("2022-12-01T14:37:58+01:00"), response.ProcessDate);
		Assert.Equal("We have refunded \u20ac 0,10 by refunding IBAN bankaccount (NL16RABO1822913977) with \u20ac 0,10", response.Description);
	}

	[Fact]
	public void RefundGetsDeserializedAllowNull()
	{
		var body = @"
{
  ""orderId"": ""1661180545X1ca9c"",
  ""transactionId"": ""EX-5431-7835-5460"",
  ""description"": ""We have refunded € 0,10 by refunding IBAN bankaccount (NL16RABO1822913977) with € 0,10"",
  ""amount"": {
    ""value"": 1000,
    ""currency"": ""EUR""
  },
  ""amountRefunded"": {
    ""value"": 10,
    ""currency"": ""EUR""
  },
  ""refundedTransactions"": [
    {
      ""amountRefunded"": {
        ""value"": 10,
        ""currency"": ""EUR""
      },
      ""refund"": {
        ""id"": ""RF-1234-1234-1234-1234""
      },
      ""createdAt"": ""2022-12-01T14:37:58+01:00"",
      ""createdBy"": ""AT-1234-4321""
    }
  ],
  ""createdAt"": ""2022-12-01T14:37:58+01:00"",
  ""createdBy"": ""AT-1234-4321"",
  ""_links"": [
    {
      ""href"": ""/transactions/EX-5431-7835-5460/refund"",
      ""rel"": ""self"",
      ""type"": ""PATCH""
    },
    {
      ""href"": ""/transactions/EX-5431-7835-5460"",
      ""rel"": ""details"",
      ""type"": ""GET""
    }
  ]
}";
		var response = JsonConvert.DeserializeObject<SuccessfulRefundResponse>(body);
		Assert.NotNull(response);
		Assert.Equal("1661180545X1ca9c", response.OrderId);
		Assert.Null(response.ProcessDate);
		Assert.Equal("We have refunded \u20ac 0,10 by refunding IBAN bankaccount (NL16RABO1822913977) with \u20ac 0,10", response.Description);
	}
}
