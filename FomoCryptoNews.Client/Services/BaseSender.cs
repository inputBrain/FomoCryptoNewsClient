using System.Text.Json;

namespace FomoCryptoNews.Client.Services;

public class BaseSender : IBaseSender
{
    private readonly HttpClient _client;

    public BaseSender(HttpClient client)
    {
        _client = client;
    }
    
    public async Task<T> ParseGet<T>(string url)
    {
        var response = await _client.GetAsync(url);
        var scriptText = await response.Content.ReadAsStringAsync();

        var appData = JsonSerializer.Deserialize<T>(scriptText, JsonSerializerOptions);

        return appData;
    }


    public async Task SendAsync(string url)
    {
        await _client.GetAsync(url);
    }


    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
}