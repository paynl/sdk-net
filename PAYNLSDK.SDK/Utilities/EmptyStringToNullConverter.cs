using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Utilities;

public class EmptyStringToNullConverter<T>  : JsonConverter<T> where T : class
{
	public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String && reader.GetString() == "")
		{
			return null;
		}

		if (reader.TokenType != JsonTokenType.StartObject)
		{
			throw new JsonException("Expected object or empty string");
		}

		return JsonSerializer.Deserialize<T>(ref reader, options);
	}

	public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) => throw new NotImplementedException();
}
