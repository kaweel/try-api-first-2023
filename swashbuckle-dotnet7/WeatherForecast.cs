using System.Net;
using Swashbuckle.AspNetCore.Filters;

namespace swashbuckle_dotnet7;

public class ErrorMsg
{

    public required string message { get; set; }
}

public class WeatherForecast
{
    public int ID { get; set; }

    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}

public class CreateWeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public string? Summary { get; set; }
}

// if you using manual annotation interface IExamplesProvider has no effect 
public class CreateWeatherForecastRequestExample : IExamplesProvider<CreateWeatherForecast>
{
    public CreateWeatherForecast GetExamples()
    {
        return new CreateWeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = -20,
            Summary = "Freezing"
        };
    }
}

public class CreateWeatherForecastResponseExamples : IExamplesProvider<WeatherForecast>
{
    public WeatherForecast GetExamples()
    {
        return new WeatherForecast
        {
            ID = 12,
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = -20,
            Summary = "Freezing"
        };
    }
}

public class CreateWeatherForecastResponseBadRequestExamples : IExamplesProvider<ErrorMsg>
{
    public ErrorMsg GetExamples()
    {
        return new ErrorMsg
        {
            message = "Bad Request"
        };
    }
}

public class GetWeatherForecastByTypeMultipleResponseExamples : IMultipleExamplesProvider<WeatherForecast>
{
    public IEnumerable<SwaggerExample<WeatherForecast>> GetExamples()
    {
        yield return SwaggerExample.Create("Freezing", "Freezing", "Stay home", new WeatherForecast
        {
            ID = 1,
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = -20,
            Summary = "Freezing"
        });

        yield return SwaggerExample.Create("Warm", "Warm", "Go out for a walk/play.", new WeatherForecast
        {
            ID = 2,
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 20,
            Summary = "Warm"
        });
    }
}

public class GetWeatherForecastByTypeNotFoundExamples : IExamplesProvider<ErrorMsg>
{
    public ErrorMsg GetExamples()
    {
        return new ErrorMsg
        {
            message = "Not Found"
        };
    }
}