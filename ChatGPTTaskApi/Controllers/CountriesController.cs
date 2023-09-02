using ChatGPTTaskApi.Models;
using ChatGPTTaskApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTTaskApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;
    private readonly ICountryFilterSortService _filterSortService;

    public CountriesController(ICountryService countryService, ICountryFilterSortService filterSortService)
    {
        _countryService = countryService;
        _filterSortService = filterSortService;
    }

    [HttpGet]
    public async Task<IEnumerable<Country>> Get([FromQuery] string? filter, 
        [FromQuery] int? maxPopulationInMillions,
        [FromQuery] bool sortByName = false)
    {
        IEnumerable<Country> countries = await _countryService.GetAllCountriesAsync();

        if (!string.IsNullOrEmpty(filter))
        {
            countries = _filterSortService.FilterByName(countries, filter);
        }
        
        if (maxPopulationInMillions.HasValue)
        {
            countries = _filterSortService.FilterByPopulation(countries, maxPopulationInMillions.Value);
        }

        if (sortByName)
        {
            countries = _filterSortService.SortByName(countries);
        }

        return countries;
    }
}
