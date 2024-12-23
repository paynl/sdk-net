using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Utilities;

public class EmptyStringToListConverter<T> : JsonConverter<List<T>>
{
	public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.String && reader.GetString() == "")
		{
			return new List<T>();
		}

		if (reader.TokenType != JsonTokenType.StartArray)
		{
			throw new JsonException("Expected array or empty string");
		}

		var list = new List<T>();
		var newOptions = new JsonSerializerOptions(options);
		newOptions.Converters.Remove(this);

		while (reader.Read())
		{
			if (reader.TokenType == JsonTokenType.EndArray)
			{
				return list;
			}

			var item = JsonSerializer.Deserialize<T>(ref reader, newOptions);
			list.Add(item);
		}

		throw new JsonException("Expected end of array");
	}

	public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
	{
		var newOptions = new JsonSerializerOptions(options);
		newOptions.Converters.Remove(this);
		JsonSerializer.Serialize(writer, value, newOptions);
	}
}

public class EmptyStringToListConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
	{
		if (!typeToConvert.IsGenericType) return false;

		return typeToConvert.GetGenericTypeDefinition() == typeof(List<>) ||
		       typeToConvert.GetGenericTypeDefinition() == typeof(IList<>) ||
		       typeToConvert.GetGenericTypeDefinition() == typeof(ICollection<>) ||
		       typeToConvert.GetGenericTypeDefinition() == typeof(IEnumerable<>);
	}

	public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		Type elementType = typeToConvert.GetGenericArguments()[0];
		Type converterType = typeof(EmptyStringToListConverter<>).MakeGenericType(elementType);
		return (JsonConverter)Activator.CreateInstance(converterType)!;
	}
}
