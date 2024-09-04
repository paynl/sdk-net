using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Utilities;

public class GenericEnumConverter<TEnum> : JsonConverter<TEnum>
	where TEnum : struct, Enum
{
	public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.String)
		{
			throw new JsonException($"Unable to convert \"{reader.GetString()}\" to enum {typeof(TEnum)}");
		}

		var stringValue = reader.GetString();
		if (!int.TryParse(stringValue, out var intValue))
		{
			throw new JsonException($"Unable to convert \"{reader.GetString()}\" to enum {typeof(TEnum)}");
		}

		if (Enum.IsDefined(typeof(TEnum), intValue))
		{
			return (TEnum)Enum.ToObject(typeof(TEnum), intValue);
		}

		throw new JsonException($"Unable to convert \"{reader.GetString()}\" to enum {typeof(TEnum)}");
	}

	public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(((int)(object)value).ToString());
	}
}
