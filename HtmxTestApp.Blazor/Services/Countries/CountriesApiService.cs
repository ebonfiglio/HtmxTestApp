using HtmxTestApp.Shared.Entities;
using System.Net.Http.Json;

namespace HtmxTestApp.Blazor.Services.Countries
{
    public class CountriesApiService : ICountriesApiService
    {
        private readonly HttpClient _httpClient;

        public CountriesApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Country>> GetAllAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/countries");
            response.EnsureSuccessStatusCode();

            List<Country> countries = await response.Content.ReadFromJsonAsync<List<Country>>() ?? new();

            return countries;
        }
    }
}
