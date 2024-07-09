using FomoCryptoNews.Client.Models;
using FomoCryptoNews.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace FomoCryptoNews.Client.ViewComponents;

public class DashboardTable : ViewComponent
{
    private readonly INewsService _newsService;
    
    public DashboardTable(INewsService newsService)
    {
        _newsService = newsService;
    }


    public async Task<IViewComponentResult> InvokeAsync(int skip, int take)
    {
        var collection = await GetItemsAsync(skip, take);
        
        return View("/Pages/Components/DashboardTableView.cshtml", collection);
    }



    private async Task<List<NewsModel>> GetItemsAsync(int skip, int take)
    {
        var collection = await _newsService.ListNews(skip, take);
        
        return collection;
    }
}