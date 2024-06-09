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
        // ASPNETCORE_ENVIRONMENT:SubSettingsIsFail3 �܂��� SettingItemIsFail �̂Ƃ���
        // DI�R���e�i�[����擾���� IOptions<TOption> �� Value ���Q�Ƃ����Ƃ��Ɍ��؂��s����B
        this.ViewBag.Options = options.Value;
        return this.View();
    }

    public IActionResult Privacy()
    {
        return this.View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
