using HtmxTestApp.Blazor.Services.Countries;
using HtmxTestApp.Blazor.Services.Teams;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace HtmxTestApp.Blazor.Components.Teams
{
    public partial class TeamForm
    {
        [Inject]
        private ICountriesApiService _countriesApiService { get; set; }

        [Inject]
        private ITeamsApiService _teamsApiService { get; set; }

        [Parameter]
        public EventCallback<Team> OnSubmit { get; set; }

        [Parameter]
        public Team? Team { get; set; }

        protected MudForm Form;

        protected List<Country> Countries { get; set; } = new List<Country>();

        protected Team _team { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Countries = await _countriesApiService.GetAllAsync();
            _team = Team ?? new();
        }

        protected async Task Save()
        {
            if (Form.IsValid)
            {
                if (_team.Id == Guid.Empty || _team.Id == null)
                {
                    // Call the create method in the teamApiService
                    await _teamsApiService.CreateAsync(_team);
                }
                else
                {
                    // Call the edit method in the teamApiService
                    await _teamsApiService.UpdateAsync(_team);
                }

                // Optionally, you may want to raise an event to notify the parent component that the operation has completed
                await OnSubmit.InvokeAsync(_team);
            }
        }

    }
}
