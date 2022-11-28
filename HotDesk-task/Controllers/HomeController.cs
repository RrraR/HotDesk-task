using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotDesk_task.Models;
using HotDesk_task.Services;

namespace HotDesk_task.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        //string sql = "EXEC exec dbo.DeleteOnExpirationDate";
        var model = new LogInViewModel();
        return View(model);
    }
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}