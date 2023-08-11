using HtmxTestApp.Blazor.Services.Teams;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Components;
using System.Linq;

namespace HtmxTestApp.Blazor.Pages.Teams
{
    public partial class Index
    {
        [Inject]
        private ITeamsApiService _teamsApiService { get; set; }

        private IEnumerable<Team> teams;

        protected override async Task OnInitializedAsync()
        {
            teams = await _teamsApiService.GetAllAsync();
        }

        // Edit method
        protected void EditTeam(Guid teamId)
        {
            // You can navigate to an edit page or open a dialog for editing
        }

        // Delete method
        protected async Task DeleteTeam(Guid teamId)
        {
            await _teamsApiService.DeleteAsync(teamId);
            teams = teams.Where(team => team.Id != teamId).ToList();
            StateHasChanged(); // Notify Blazor that the state has changed and the UI needs to be updated
        }
    }
}
