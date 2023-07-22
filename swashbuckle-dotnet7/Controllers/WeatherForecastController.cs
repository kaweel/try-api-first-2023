using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

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

    private static List<WeatherForecast> _weatherForecasts = Enumerable.Range(1, 2).Select(index => new WeatherForecast
    {
        ID = index,
        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
        .ToList();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get all weather forecast.
    /// </summary>
    /// <returns>List of weather forecast</returns>
    [HttpGet("")]
    public List<WeatherForecast> Get()
    {
        return _weatherForecasts;
    }

    /// <summary>
    /// Create weather forecast.
    /// </summary>
    /// <returns>Newly weather forecast</returns>
    [HttpPost("")]
    [Produces("application/json")]
    [SwaggerRequestExample(typeof(CreateWeatherForecast), typeof(CreateWeatherForecastResponseExamples))]
    [SwaggerResponse(StatusCodes.Status201Created, "The weather forecast was created", typeof(CreateWeatherForecast))]
    [SwaggerResponseExample(StatusCodes.Status201Created, typeof(CreateWeatherForecastResponseExamples))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request", typeof(CreateWeatherForecast))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(CreateWeatherForecastResponseBadRequestExamples))]
    public ActionResult<WeatherForecast> Create([FromBody] CreateWeatherForecast request)
    {
        var element = new WeatherForecast
        {
            ID = _weatherForecasts.Last().ID + 1,
            Date = request.Date,
            TemperatureC = request.TemperatureC,
            Summary = request.Summary
        };
        _weatherForecasts.Add(element);
        return StatusCode(StatusCodes.Status201Created, element);
    }

    /// <summary>
    /// Get weather forecast by type.
    /// </summary>
    /// <returns>Weather forecast</returns>
    /// <response code="200">Found</response>
    /// <response code="404">Not found</response>
    /// <param name="type" example="Freezing">Type of weather</param>
    [HttpGet("{type}")]
    [Produces("application/json")]
    [SwaggerResponse(StatusCodes.Status200OK, "found", typeof(CreateWeatherForecast))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetWeatherForecastByTypeMultipleResponseExamples))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "not found", typeof(ErrorMsg))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(GetWeatherForecastByTypeNotFoundExamples))]
    public WeatherForecast GetByType([FromRoute] string type)
    {
        return _weatherForecasts.First(x => x.Summary == type);
    }


}
