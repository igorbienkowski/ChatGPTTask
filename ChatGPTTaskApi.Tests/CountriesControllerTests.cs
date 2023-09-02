using Moq;
using ChatGPTTaskApi.Controllers;
using ChatGPTTaskApi.Models;
using ChatGPTTaskApi.Services;

namespace ChatGPTTaskApi.Tests
{
    public class CountriesControllerTests
    {
        private readonly Mock<ICountryService> _mockCountryService;
        private readonly Mock<ICountryFilterSortService> _mockFilterSortService;
        private readonly CountriesController _controller;

        public CountriesControllerTests()
        {
            _mockCountryService = new Mock<ICountryService>();
            _mockFilterSortService = new Mock<ICountryFilterSortService>();
            _controller = new CountriesController(_mockCountryService.Object, _mockFilterSortService.Object);
        }
        
        [Fact]
        public async void Get_WithoutFilters_ReturnsAllCountries()
        {
            // Arrange
            var allCountries = new List<Country>
            {
                new Country { Cca2 = "x", Cca3 = "A", Name = new Name { Common = "CountryA" } },
                new Country { Cca2 = "x", Cca3 = "B", Name = new Name { Common = "CountryB" } },
                new Country { Cca2 = "x", Cca3 = "C", Name = new Name { Common = "CountryC" } }
            };
            _mockCountryService.Setup(service => service.GetAllCountriesAsync()).ReturnsAsync(allCountries);

            // Act
            var result = (await _controller.Get(null, null, null, false)).ToList();

            // Assert
            Assert.Equal(allCountries.Count, result.Count);
        }

        [Fact]
        public async Task Get_WithFilter_ReturnsFilteredCountries()
        {
            var allCountries = new List<Country>
            {
                new Country { Cca3 = "A", Name = new Name { Common = "CountryA" } },
                new Country { Cca3 = "B", Name = new Name { Common = "CountryB" } },
                new Country { Cca3 = "C", Name = new Name { Common = "CountryC" } }
            };
            _mockCountryService.Setup(service => service.GetAllCountriesAsync()).ReturnsAsync(allCountries);
            
            var filteredCountries = allCountries.Where(c => c.Name.Common.Contains("CountryB")).ToList();
            _mockFilterSortService.Setup(s => s.FilterByName(allCountries, "CountryB")).Returns(filteredCountries);

            var result = (await _controller.Get("CountryB", null, null, false)).ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("CountryB", result.First().Name.Common);
        }

        [Fact]
        public async Task Get_WithMaxPopulation_ReturnsCountriesBelowPopulation()
        {
            var allCountries = new List<Country>
            {
                new Country { Cca3 = "A", Name = new Name { Common = "CountryA" }, Population = 5_000_000},
                new Country { Cca3 = "B", Name = new Name { Common = "CountryB" }, Population = 15_000_000 }
            };
            _mockCountryService.Setup(service => service.GetAllCountriesAsync()).ReturnsAsync(allCountries);
            var filteredCountries = allCountries.Where(c => c.Population <= 10_000_000).ToList();
            _mockFilterSortService.Setup(s => s.FilterByPopulation(allCountries, 10)).Returns(filteredCountries);

            var result = (await _controller.Get(null, 10, null, false)).ToList();

            Assert.Single(result);
            Assert.Equal("CountryA", result.First().Name.Common);
        }

        [Fact]
        public async Task Get_WithSortByName_ReturnsSortedCountries()
        {
            var allCountries = new List<Country>
            {
                new Country { Cca3 = "A", Name = new Name { Common = "CountryA" } },
                new Country { Cca3 = "C", Name = new Name { Common = "CountryC" } },
                new Country { Cca3 = "B", Name = new Name { Common = "CountryB" } }
            };
            _mockCountryService.Setup(service => service.GetAllCountriesAsync()).ReturnsAsync(allCountries);
            var sortedCountries = allCountries.OrderBy(c => c.Name.Common).ToList();
            _mockFilterSortService.Setup(s => s.SortByName(allCountries)).Returns(sortedCountries);

            var result = (await _controller.Get(null, null, null, true)).ToList();

            // Assert
            Assert.Equal(3, result.Count);
            Assert.Equal("CountryA", result.First().Name.Common);
            Assert.Equal("CountryC", result.Last().Name.Common);
        }

        [Fact]
        public async Task Get_WithRecordsLimit_ReturnsLimitedCountries()
        {
            var allCountries = new List<Country>
            {
                new Country { Cca3 = "A", Name = new Name { Common = "CountryA" } },
                new Country { Cca3 = "B", Name = new Name { Common = "CountryB" } },
                new Country { Cca3 = "C", Name = new Name { Common = "CountryC" } }
            };
            _mockCountryService.Setup(s => s.GetAllCountriesAsync()).ReturnsAsync(allCountries);

            var limitedCountries = allCountries.Take(2).ToList();
            _mockFilterSortService.Setup(s => s.Paginate(allCountries, 2)).Returns(limitedCountries);

            var result = (await _controller.Get(null, null, 2, false)).ToList();

            // Assert
            Assert.Equal(2, result.Count);
        }
    }
}