using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    /// EndpointDescription
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    [HttpGet("{number}")]
    [SwaggerResponse(201, "The weather values", typeof(IEnumerable<WeatherForecast>), ContentTypes = new string[] { "application/json" })]
    [SwaggerResponse(500, "Server error", typeof(ProblemDetails))]
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
