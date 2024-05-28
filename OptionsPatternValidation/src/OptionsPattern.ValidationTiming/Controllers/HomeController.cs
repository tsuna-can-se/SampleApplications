using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPattern.ValidationTiming.Configurations;
using OptionsPattern.ValidationTiming.Models;

namespace OptionsPattern.ValidationTiming.Controllers;

public class HomeController(IOptions<OptionsPatternSettings> options) : Controller
{
    public IActionResult Index()
    {
        ViewBag.Options = options.Value;
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
