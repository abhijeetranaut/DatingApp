using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://weatherapi-com.p.rapidapi.com";
    private const string RapidAPIKey = "b058d5e763msh7f90b2a34c987cfp1d69adjsn6243c98718cd";
    private const string RapidAPIHost = "weatherapi-com.p.rapidapi.com";

    public WeatherService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidAPIKey);
        _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidAPIHost);
    }

    public async Task<ActionResult<string>> GetWeatherData(string queryParameter)
    {
        try
        {
            var requestUri = new Uri($"{BaseUrl}/current.json?q={Uri.EscapeDataString(queryParameter)}");
            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            return body;
        }
        catch (HttpRequestException ex)
        {
            throw new Exception("Error occured while getting the weather. Error: ",ex);
        }
    }
}
