using ErrorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        try
        {
            // Burada Privacy işlemleri yapılır
            // Örneğin, bir istisna fırlatılabilir
            throw new Exception("An error occurred in the Privacy action.");
        }
        catch (Exception ex)
        {
            // Hata durumunda loglama yapabilir ve özel hata sayfasına yönlendirme yapabilirsiniz
            _logger.LogError(ex, "An error occurred in the Privacy action.");

            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View("_Error", errorViewModel);
        }
    }

    [Route("Home/Error")]
    public IActionResult Error()
    {
        var errorViewModel = new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        };

        return View("_Error", errorViewModel);
    }
}
