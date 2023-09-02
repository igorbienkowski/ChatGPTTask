using ChatGPTTaskApi.Models;

namespace ChatGPTTaskApi.Services;

public class CountryFilterSortService : ICountryFilterSortService
{
    public IEnumerable<Country> FilterByName(IEnumerable<Country> countries, string filter)
    {
        filter = filter.Trim().ToLower();
        return countries.Where(c => c.Cca2!.ToLower().Contains(filter) 
                                    || c.Cca3!.ToLower().Contains(filter) 
                                    || c.Name!.Common!.ToLower().Contains(filter));
    }

    public IEnumerable<Country> FilterByPopulation(IEnumerable<Country> countries, int maxPopulationInMillions)
    {
        return countries.Where(country => country.Population < maxPopulationInMillions * 1_000_000);
    }

    public IEnumerable<Country> SortByName(IEnumerable<Country> countries)
    {
        return countries.OrderBy(c => c.Name!.Common);
    }
    
    public IEnumerable<Country> Paginate(IEnumerable<Country> countries, int recordsLimit)
    {
        return countries.Take(recordsLimit);
    }
}