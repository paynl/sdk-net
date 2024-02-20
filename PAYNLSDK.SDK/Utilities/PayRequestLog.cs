namespace PayNlSdk.Sdk.Utilities;

public class PayRequestLog
{
    public string? Url { get; set; }
    public int StatusCode { get; set; }
    public string? RequestBody { get; set; }
    public string? ResponseBody { get; set; }
}
