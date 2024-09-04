using System.Text.Json;
using PayNlSdk.Sdk.Utilities;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;

namespace PayNlSdk.IntegrationTests.V2.Utility;

public class JsonConverters
{
	private enum TestEnum
	{
		Value1 = 1,
		Value2 = 2,
		Value3 = 3
	}

	[Fact]
	public void Read_ValidStringInteger_ReturnsCorrectEnum()
	{
		var json = "\"2\"";
		var result = JsonSerializer.Deserialize<TestEnum>(json, new JsonSerializerOptions
		{
			Converters = { new GenericEnumConverter<TestEnum>() }
		});

		Assert.Equal(TestEnum.Value2, result);
	}

	[Fact]
	public void Read_InvalidStringInteger_ThrowsJsonException()
	{
		var json = "\"4\"";
		Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<TestEnum>(json, new JsonSerializerOptions
		{
			Converters = { new GenericEnumConverter<TestEnum>() }
		}));
	}

	[Fact]
	public void Read_NonIntegerString_ThrowsJsonException()
	{
		var json = "\"notAnInteger\"";
		Assert.Throws<JsonException>(() => JsonSerializer.Deserialize<TestEnum>(json, new JsonSerializerOptions
		{
			Converters = { new GenericEnumConverter<TestEnum>() }
		}));
	}

	[Fact]
	public void Write_EnumValue_WritesCorrectStringInteger()
	{
		var enumValue = TestEnum.Value3;
		var json = JsonSerializer.Serialize(enumValue, new JsonSerializerOptions
		{
			Converters = { new GenericEnumConverter<TestEnum>() }
		});

		Assert.Equal("\"3\"", json);
	}

	[Fact]
	public void ReadWrite_RoundTrip_PreservesValue()
	{
		var original = TestEnum.Value1;
		var json = JsonSerializer.Serialize(original, new JsonSerializerOptions
		{
			Converters = { new GenericEnumConverter<TestEnum>() }
		});
		var result = JsonSerializer.Deserialize<TestEnum>(json, new JsonSerializerOptions
		{
			Converters = { new GenericEnumConverter<TestEnum>() }
		});

		Assert.Equal(original, result);
	}
}
