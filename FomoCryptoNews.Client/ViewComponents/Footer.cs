﻿using Microsoft.AspNetCore.Mvc;

namespace FomoCryptoNews.Client.ViewComponents;

public class Footer : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View("/Pages/Components/FooterView.cshtml");
    }
}