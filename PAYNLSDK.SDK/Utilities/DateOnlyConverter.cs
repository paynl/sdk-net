using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Utilities;

public class DateOnlyConverter : JsonConverter<DateTime?>
{
	public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		var dateString = reader.GetString();
		if (string.IsNullOrEmpty(dateString))
		{
			return null;
		}
		return DateTime.Parse(reader.GetString());
	}

	public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value?.ToString("yyyy/MM/dd"));
	}
}
