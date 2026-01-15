using System.Text.Json;
using System.Text.Json.Serialization;
using PayNlSdk.Sdk.V2.DataTransferModels.DirectDebit;

namespace PayNlSdk.Sdk.Utilities;

public class Json
{
    private static readonly JsonSerializerOptions? SerializerOptions = new()
    {
        WriteIndented = true,
        Converters = { new EmptyStringToListConverterFactory() },
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
    };

    public static string Serialize(object input)
    {
        return JsonSerializer.Serialize(input, SerializerOptions);
    }

    public static async Task<T?> DeserializeAsync<T>(Stream input)
    {
        return await JsonSerializer.DeserializeAsync<T>(input, SerializerOptions);
    }
}
