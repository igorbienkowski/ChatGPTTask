using ChatGPTTaskApi.Models;

namespace ChatGPTTaskApi.Services;

public interface ICountryFilterSortService
{
    IEnumerable<Country> FilterByName(IEnumerable<Country> countries, string filter);
    IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, int maxPopulationInMillions);
    IEnumerable<Country> SortByName(IEnumerable<Country> countries);
}