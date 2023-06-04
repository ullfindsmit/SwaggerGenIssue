using Microsoft.AspNetCore.Mvc;
using static SDS.APIv5.Controllers.WeatherForecastController;

namespace SDS.APIv5.Controllers;

public class MySmartList<GenericType>
{
    public int TotalRows { get; set; }
    public List<GenericType> data { get; set; } = new List<GenericType>();
    public int PageNum { get; set; }
    public int PageSize { get; set; }
}

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [Route("GetWeatherForecast")]
    [HttpGet]
    public MySmartList<WeatherForecast> GetWeatherForecast()
    {
        MySmartList<WeatherForecast> result = new MySmartList<WeatherForecast>(); 

        result.data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToList();

        return result;
    }

    [Route("GetNumbers")]
    [HttpGet]
    public MySmartList<int> GetNumbers()
    {
        MySmartList<int> result = new MySmartList<int>();
        for (int i = 0; i < 10; i++)
        {
            result.data.Add(i);
        }
        return result;
    }

    [Route("GetStrings")]
    [HttpGet]
    public MySmartList<string> GetStrings()
    {
        MySmartList<string> result = new MySmartList<string>();
        for (int i = 0; i < 10; i++)
        {
            result.data.Add(new Guid().ToString());
        }
        return result;
    }

}
