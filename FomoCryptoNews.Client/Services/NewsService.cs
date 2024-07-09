using FomoCryptoNews.Client.Models;

namespace FomoCryptoNews.Client.Services;

public class NewsService : INewsService
{
    private readonly IBaseSender _sender;
    
    public NewsService(IBaseSender sender)
    {
        _sender = sender;
    }


    public async Task<List<NewsModel>> ListNews(int skip, int take)
    {
        var collection =  await _sender.ParseGet<NewsModel[]>($"http://localhost:5000/api/News/GetAll?pageIndex={skip}&pageSize={take}");
        
        return collection.ToList();
    }
}