namespace project_foodie.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using project_foodie.Model;

public class ExampleApiService
{
    public string GetExampleApiAsync()
    {
        var weatherForecast = new WeatherForecast
        {
            Date = DateTime.Parse("2019-08-01"),
            TemperatureCelsius = 25,
            Summary = "Hot"
        };

        string jsonString = JsonSerializer.Serialize(weatherForecast);

        return jsonString;
    }
}