using Microsoft.AspNetCore.Mvc;

namespace swashbuckle_dotnet7.Controllers;

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

    public IEnumerable<WeatherForecast> weatherForecasts = Enumerable.Range(1, 2).Select(index => new WeatherForecast
    {
        ID = index,
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    }).ToArray();

    [HttpGet("")]
    public IEnumerable<WeatherForecast> Get()
    {
        return weatherForecasts;
    }

    /// <summary>
    /// Get weather forecast by id.
    /// </summary>
    /// <response code="200">Found</response>
    /// <response code="404">Not found</response>
    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public WeatherForecast GetById([FromRoute] int id)
    {
        return weatherForecasts.First(x => x.ID == id);
    }


}
