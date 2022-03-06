using Microsoft.AspNetCore.Mvc;

namespace TemplateProject.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
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

    /// <summary>
    /// Athy_EndpointDescription
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpGet("{number}")]
    [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), (200), "application/json")]
    public IEnumerable<WeatherForecast> Get([FromRoute] int number)
    {
        return Enumerable.Range(1, number).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
