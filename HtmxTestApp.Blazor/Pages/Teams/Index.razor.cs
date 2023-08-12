using HtmxTestApp.Blazor.Components.Teams;
using HtmxTestApp.Blazor.Services.Teams;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Linq;

namespace HtmxTestApp.Blazor.Pages.Teams
{
    public partial class Index
    {
        [Inject]
        private ITeamsApiService _teamsApiService { get; set; }
        
        [Inject]
        private IDialogService _dialogService { get; set; }

        protected IEnumerable<Team> teams;

        protected Team selectedTeam;

        protected override async Task OnInitializedAsync()
        {
            teams = await _teamsApiService.GetAllAsync();
        }

        protected void QuickEditTeam(Team team)
        {
            selectedTeam = team;

            // Open the dialog using the DialogService
            DialogParameters parameters = new DialogParameters { ["Team"] = team };
            _dialogService.Show<TeamFormDialog>("Edit Team", parameters, new DialogOptions
            {
                CloseButton = true,
                DisableBackdropClick = true
            });
        }

        private async void Dialog_OnClose(DialogResult obj)
        {
            // Reload teams when the dialog is closed
            await ReloadTeams();
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

        protected async Task ReloadTeams()
        {
            teams = await _teamsApiService.GetAllAsync();
            StateHasChanged();
        }
    }
}
