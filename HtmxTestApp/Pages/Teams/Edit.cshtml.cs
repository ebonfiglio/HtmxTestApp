using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxTestApp.Pages.Teams
{
    public class EditModel : PageModel
    {
        private ITeamService teamService;
        public Team Team { get; set; } = new();
        public EditModel(ITeamService teamService)
        {
            this.teamService = teamService;
        }
        public async Task<IActionResult> OnGet(string id)
        {
            bool isValid = Guid.TryParse(id, out Guid teamId);
            if (!isValid) return Redirect("Error"); 

            Team = await teamService.GetAsync(teamId);
            return Page();
        }
    }
}
