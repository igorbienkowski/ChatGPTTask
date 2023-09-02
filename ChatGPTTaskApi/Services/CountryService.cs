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
    
    public async Task<IEnumerable<Country>> GetCountriesByNameAsync(string? filter)
    {
        var allCountries = await GetAllCountriesAsync();

            filter = filter.Trim().ToLower();
            allCountries = allCountries.Where(
                    c => c.Cca2.ToLower().Contains(filter) 
                         ||c.Cca3.ToLower().Contains(filter) 
                         || c.Name.Common.ToLower().Contains(filter)).ToList();

        return allCountries;
    }
    
    public async Task<IEnumerable<Country>> GetCountriesByPopulationAsync(int? maxPopulationInMillions)
    {
        var allCountries = await GetAllCountriesAsync();
    
        return allCountries.Where(country => country.Population < maxPopulationInMillions * 1_000_000);
    }
}
