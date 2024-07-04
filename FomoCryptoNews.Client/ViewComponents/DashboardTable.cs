using FomoCryptoNews.Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace FomoCryptoNews.Client.ViewComponents;

public class DashboardTable : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var collection = NewsModel.FakerCollection();
        
        return View("/Pages/Components/DashboardTableView.cshtml", collection);
    }
}