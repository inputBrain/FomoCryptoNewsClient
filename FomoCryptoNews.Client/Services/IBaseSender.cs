namespace FomoCryptoNews.Client.Services;

public interface IBaseSender
{
    Task<T> ParseGet<T>(string url);

    Task SendAsync(string url);
}