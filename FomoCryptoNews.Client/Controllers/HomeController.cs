using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FomoCryptoNews.Client.Models;
using FomoCryptoNews.Client.Services;

namespace FomoCryptoNews.Client.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly INewsService _newsService;


    public HomeController(ILogger<HomeController> logger, INewsService newsService)
    {
        _logger = logger;
        _newsService = newsService;
    }

    public IActionResult Index()
    {
        return View();
    }

    
    public async Task<IActionResult> ApproveNews(int newsId)
    {
        await _newsService.ApproveNews(newsId);
        
        return View("Index");
    }
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            }
        );
    }
}