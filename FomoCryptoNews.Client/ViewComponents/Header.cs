using Microsoft.AspNetCore.Mvc;

namespace FomoCryptoNews.Client.ViewComponents;

public class Header : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Pages/Components/HeaderView.cshtml");
    }
}