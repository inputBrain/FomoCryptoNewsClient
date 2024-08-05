using FomoCryptoNews.Client.Models;

namespace FomoCryptoNews.Client.Services;

public class NewsService : INewsService
{
    private readonly IBaseSender _sender;

    private const string BaseUrl = "http://localhost:5000/api/News";
    
    public NewsService(IBaseSender sender)
    {
        _sender = sender;
    }


    public async Task ApproveNews(int newsId)
    {
        await _sender.SendAsync($"{BaseUrl}/ApproveNews?newsId={newsId}");
    }


    public async Task<List<NewsModel>> ListNews(int skip, int take)
    {
        var collection =  await _sender.ParseGet<NewsModel[]>($"{BaseUrl}/GetAll?pageIndex={skip}&pageSize={take}");
        
        return collection.ToList();
    }
}