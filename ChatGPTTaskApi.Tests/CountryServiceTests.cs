using Moq;
using Xunit;
using ChatGPTTaskApi.Services;
using System.Net.Http;
using ChatGPTTaskApi.Models;
using Newtonsoft.Json;

namespace ChatGPTTaskApi.Tests
{
    public class CountryServiceTests
    {
        private readonly Mock<IHttpClientWrapper> _mockHttpClient;
        private readonly CountryService _service;

        public CountryServiceTests()
        {
            _mockHttpClient = new Mock<IHttpClientWrapper>();
            _service = new CountryService(_mockHttpClient.Object);
        }

        [Fact]
        public async Task GetAllCountriesAsync_ReturnsListOfCountries()
        {
            // Arrange
            var mockCountries = new List<Country>
            {
                new Country { Cca3 = "DE", Name = new Name { Common = "Germany" }, Population = 80_000_000 },
                // ... other mock countries
            };

            var json = JsonConvert.SerializeObject(mockCountries);
            _mockHttpClient.Setup(client => client.GetStringAsync(It.IsAny<string>())).ReturnsAsync(json);

            // Act
            var result = await _service.GetAllCountriesAsync();

            // Assert
            Assert.Equal(mockCountries.Count, result.Count());
            // ... Further assertions based on your requirements ...
        }

        // Additional tests can be written for error scenarios, empty results etc.
    }
}