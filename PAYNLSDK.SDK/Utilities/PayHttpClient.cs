using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using PayNlSdk.Sdk.V3.DataTransferObjects;

namespace PayNlSdk.Sdk.Utilities;

internal class PayHttpClient
{
    private readonly HttpClient _client;
    private readonly Action<PayRequestLog>? _onRequest;

    public PayHttpClient(HttpClient client, Action<PayRequestLog>? onRequest)
    {
        _client = client;
        _onRequest = onRequest;
    }

    internal async Task<T?> GetAsync<T>(string url)
    {
        var response = await GetAsyncNoExceptionHandling(url);
        await response.HandleException();
        var result = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<T>(result);
    }

    internal async Task<HttpResponseMessage> GetAsyncNoExceptionHandling(string url)
    {
        var response = await _client.GetAsync(url);
        await CallCallback(response);
        return response;
    }

    internal async Task<T?> PostAsync<T>(string url, object? body = null)
    {
        StringContent? content = null;
        if (body != null)
        {
            content = new StringContent(Json.Serialize(body), Encoding.UTF8, "application/json");
        }

        var response = await _client.PostAsync(url, content);
        await CallCallback(response);

        await response.HandleException();
        var result = await response.Content.ReadAsStreamAsync();
        return await Json.DeserializeAsync<T>(result);
    }

    internal async Task<T?> PostUrlEncodedAsync<T>(string url, Dictionary<string, string> body)
    {
        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
        requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        requestMessage.Content = new FormUrlEncodedContent(body);

        var response = await _client.SendAsync(requestMessage);
        await CallCallback(response);

        await response.HandleException();
        var result = await response.Content.ReadAsStreamAsync();
        return await Json.DeserializeAsync<T>(result);
    }

    internal async Task<T?> PatchAsync<T>(string url, object? body = null)
    {
        var response = await PatchAsync(url, body);
        var result = await response.Content.ReadAsStreamAsync();
        return await Json.DeserializeAsync<T>(result);
    }

    internal async Task<HttpResponseMessage> PatchAsync(string url, object? body = null)
    {
        StringContent? content = null;
        if (body != null)
        {
            content = new StringContent(Json.Serialize(body), Encoding.UTF8, "application/json");
        }

        var response = await _client.PatchAsync(url, content);
        await CallCallback(response);

        await response.HandleException();
        return response;
    }

    internal async Task DeleteAsync(string url)
    {
        var response = await _client.DeleteAsync(url);
        await CallCallback(response);

        await response.HandleException();
    }

    private async Task CallCallback(HttpResponseMessage message)
    {
        if (_onRequest == null)
        {
            return;
        }

        var log = new PayRequestLog()
        {
            Url = message.RequestMessage.RequestUri.AbsoluteUri,
            RequestBody = await message.RequestMessage.Content.ReadAsStringAsync(),
            ResponseBody = await message.Content.ReadAsStringAsync(),
            StatusCode = (int)message.StatusCode
        };
        _onRequest(log);
    }
}
