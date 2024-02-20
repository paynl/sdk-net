using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PayNlSdk.Sdk.Utilities;

public class DateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        DateTime.TryParse(reader.GetString(), out var result);
        return result;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? dateTimeValue, JsonSerializerOptions options)
    {
        writer.WriteStringValue(dateTimeValue.HasValue
            ? dateTimeValue.Value.ToString(CultureInfo.CurrentCulture)
            : string.Empty);
    }
}