using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPattern.Web.Configurations;
using OptionsPattern.Web.Models;

namespace OptionsPattern.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly OptionsPatternSettings options;

    public HomeController(ILogger<HomeController> logger, IOptions<OptionsPatternSettings> options)
    {
        this.logger = logger;
        this.options = options.Value;
    }

    public IActionResult Index()
    {
        this.ViewBag.Options = this.options;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
