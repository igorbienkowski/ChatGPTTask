using ChatGPTTaskApi.Models;
using ChatGPTTaskApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTTaskApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet]
    public async Task<IEnumerable<Country>> Get()
    {
        return await _countryService.GetAllCountriesAsync();
    }
}
