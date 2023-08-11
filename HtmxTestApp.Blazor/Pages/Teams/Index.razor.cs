using HtmxTestApp.Blazor.Services.Teams;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Components;

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
    }
}
