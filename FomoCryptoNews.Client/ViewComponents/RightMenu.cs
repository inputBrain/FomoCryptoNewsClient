using Microsoft.AspNetCore.Mvc;

namespace FomoCryptoNews.Client.ViewComponents;

public class RightMenu : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Pages/Components/RightMenuView.cshtml");
    }
}