// WeatherController.cs

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
public class WeatherController : Controller
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeather(string queryParameter)
    {
        try
        {
            var weatherData = await _weatherService.GetWeatherData(queryParameter);
            return Ok(weatherData);
        }
        catch (HttpRequestException ex)
        {
            return BadRequest("Error occurred while getting the weather. Error: " + ex.Message);
        }
    }
}
