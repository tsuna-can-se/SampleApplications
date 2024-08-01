using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DummyAuthentication.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private readonly ILogger<WeatherForecastController> logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        this.logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Authorize(Roles = "Admin")] // Admin ���[�������F�؍ς݃��[�U�[�ɂ����A�N�Z�X�������܂��B
    public IEnumerable<WeatherForecast> Get()
    {
        // ����m�F�̂��߁A���[�U�[�̏������O�ɏo�͂��܂��B
        this.logger.LogInformation($"Authenticated user:{this.User.Identity?.Name}");
        this.logger.LogInformation($"User is authenticated:{this.User.Identity?.IsAuthenticated}");
        this.logger.LogInformation($"Has \"Admin\" role:{this.User.IsInRole("Admin")}");

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
