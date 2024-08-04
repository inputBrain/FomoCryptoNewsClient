using FomoCryptoNews.Client.Models;

namespace FomoCryptoNews.Client.Services;

public interface INewsService
{
    Task<List<NewsModel>> ListNews(int skip, int take);

    Task ApproveNews(int newsId);
}