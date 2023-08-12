using HtmxTestApp.Shared.Entities;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;

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


        public async Task DeleteAsync(Guid id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/teams/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Team> CreateAsync(Team team)
        {
            // Serialize the team object to JSON
            var teamJson = new StringContent(JsonSerializer.Serialize(team), Encoding.UTF8, "application/json");

            // Send the POST request to the endpoint
            HttpResponseMessage response = await _httpClient.PostAsync("/api/teams", teamJson);

            // Ensure a successful response
            response.EnsureSuccessStatusCode();

            // Deserialize the response content to a Team object
            string responseBody = await response.Content.ReadAsStringAsync();
            Team createdTeam = JsonSerializer.Deserialize<Team>(responseBody);

            return createdTeam;
        }

        public async Task<Team> UpdateAsync(Team team)
        {
            // Serialize the team object to JSON
            var teamJson = new StringContent(JsonSerializer.Serialize(team), Encoding.UTF8, "application/json");

            // Send the POST request to the endpoint
            HttpResponseMessage response = await _httpClient.PutAsync("/api/teams", teamJson);

            // Ensure a successful response
            response.EnsureSuccessStatusCode();

            // Deserialize the response content to a Team object
            string responseBody = await response.Content.ReadAsStringAsync();
            Team updatedTeam = JsonSerializer.Deserialize<Team>(responseBody);

            return updatedTeam;
        }
    }
}
