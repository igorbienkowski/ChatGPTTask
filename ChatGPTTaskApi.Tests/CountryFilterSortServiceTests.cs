using ChatGPTTaskApi.Models;
using ChatGPTTaskApi.Services;

namespace ChatGPTTaskApi.Tests;

public class CountryFilterSortServiceTests
{
    private readonly ICountryFilterSortService _service = new CountryFilterSortService();

        [Fact]
        public void FilterByName_MatchesCca2_ReturnsMatchingCountries()
        {
            var countries = GetSampleCountries();

            var result = _service.FilterByName(countries, "de").ToList();

            Assert.Single(result);
            Assert.Equal("Germany", result.First().Name.Common);
        }

        [Fact]
        public void FilterByName_MatchesName_ReturnsMatchingCountries()
        {
            var countries = GetSampleCountries();

            var result = _service.FilterByName(countries, "Germany").ToList();

            Assert.Single(result);
            Assert.Equal("Germany", result.First().Name.Common);
        }

        [Fact]
        public void FilterByPopulation_BelowThreshold_ReturnsMatchingCountries()
        {
            var countries = GetSampleCountries();

            var result = _service.FilterByPopulation(countries, 70).ToList();

            Assert.Single(result);
            Assert.Equal("France", result.First().Name.Common);
        }

        [Fact]
        public void SortByName_AscendingOrder_ReturnsSortedCountries()
        {
            var countries = GetSampleCountries();

            var result = _service.SortByName(countries).ToList();

            Assert.Equal(2, result.Count);
            Assert.Equal("France", result.First().Name.Common);
            Assert.Equal("Germany", result.Last().Name.Common);
        }
        
        [Fact]
        public void Paginate_LimitsToSpecifiedNumber_ReturnsLimitedCountries()
        {
            var countries = GetSampleCountries();

            var result = _service.Paginate(countries, 1).ToList();

            Assert.Single(result);
        }

        private static List<Country> GetSampleCountries()
        {
            return new List<Country>
            {
                new Country { Cca2 = "DE", Cca3 = "xx", Name = new Name { Common = "Germany" }, Population = 80_000_000 },
                new Country { Cca2 = "FR", Cca3 = "xx", Name = new Name { Common = "France" }, Population = 67_000_000 }
            };
        }
    
}