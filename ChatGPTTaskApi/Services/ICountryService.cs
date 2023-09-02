using ChatGPTTaskApi.Models;

namespace ChatGPTTaskApi.Services;

public interface ICountryService
{
    Task<IEnumerable<Country>> GetAllCountriesAsync();
    Task<IEnumerable<Country>> GetCountriesByNameAsync(string filter = "");
}