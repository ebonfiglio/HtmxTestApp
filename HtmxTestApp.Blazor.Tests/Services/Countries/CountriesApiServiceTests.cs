using HtmxTestApp.Blazor.Services.Teams;
using HtmxTestApp.Shared.Entities;
using Moq.Protected;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmxTestApp.Blazor.Services.Countries;

namespace HtmxTestApp.Blazor.Tests.Services.Countries
{
    public class CountriesApiServiceTests
    {
        private readonly ICountriesApiService _countriesApiService;
        private readonly Mock<HttpMessageHandler> _handlerMock;

        private static readonly Guid _countryId1 = new Guid("b974c918-e33d-4f97-8d41-94310991baa8");
        private static readonly Guid _countryId2 = new Guid("78717a30-19bc-46e4-be69-dea4dd0df95b");

        private static readonly List<Country> _countries = new List<Country>()
        {
            new()
            {
                Id= _countryId1,
                Name = "Country A"
            },
            new()
            {
                Id = _countryId2,
                Name = "Country B"
            }
        };

        public CountriesApiServiceTests()
        {
            _handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(JsonConvert.SerializeObject(_countries)),
                })
                .Verifiable();

            var httpClient = new HttpClient(_handlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:7141"),
            };

            _countriesApiService = new CountriesApiService(httpClient);
        }

        [Fact]
        public async void GetAllAsyncTest()
        {
            List<Country> countries = await _countriesApiService.GetAllAsync();

            Assert.Equal(2, countries.Count());
            Assert.Equal(_countryId1, countries.First().Id);
            Assert.Equal("Country A", countries.First().Name);
            Assert.Equal(_countryId2, countries.Last().Id);
            Assert.Equal("Country B", countries.Last().Name);

            _handlerMock.Protected().Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>());
        }
    }
}
