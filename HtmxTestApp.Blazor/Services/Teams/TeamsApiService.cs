using HtmxTestApp.Shared.Entities;
using System.Collections.Generic;
using System.Net.Http.Json;

namespace HtmxTestApp.Blazor.Services.Teams
{
    public class TeamsApiService : ITeamsApiService
    {
        private readonly HttpClient _httpClient;

        public TeamsApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Team>> GetAllAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/teams");
            response.EnsureSuccessStatusCode();

            List<Team> teams = await response.Content.ReadFromJsonAsync<List<Team>>() ?? new();

            return teams;
        }
    }
}
