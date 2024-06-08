using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPattern.Web.Configurations;
using OptionsPattern.Web.Models;

namespace OptionsPattern.Web.Controllers;

public class HomeController(IOptions<OptionsPatternSettings> options) : Controller
{
    public IActionResult Index()
    {
        // ASPNETCORE_ENVIRONMENT:SubSettingsIsFail3 または SettingItemIsFail のときは
        // DIコンテナーから取得した IOptions<TOption> の Value を参照したときに検証が行われる。
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
