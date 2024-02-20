namespace PayNlSdk.Sdk.Utilities;

public class Core
{
    public Uri Url { get; }
    public string Text { get; }
    public bool IsHealthy { get; set; }

    public Core(Uri url, string text, bool isHealthy = true)
    {
        Url = url;
        Text = text;
        IsHealthy = isHealthy;
    }
}