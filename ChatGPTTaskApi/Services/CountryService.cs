using System.Text.Json;
using ChatGPTTaskApi.Models;
using Newtonsoft.Json;

namespace ChatGPTTaskApi.Services;

public class CountryService : ICountryService
{
    private const string BaseUrl = "https://restcountries.com/v3.1";
    private readonly HttpClient _httpClient;

    // Constructor injection for HttpClient
    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Country>> GetAllCountriesAsync()
    {
        var response = await _httpClient.GetStringAsync($"{BaseUrl}/all");
        return JsonConvert.DeserializeObject<IEnumerable<Country>>(response);
    }
}
