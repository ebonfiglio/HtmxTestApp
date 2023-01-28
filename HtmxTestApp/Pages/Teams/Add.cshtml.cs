using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HtmxTestApp.Pages.Teams
{
    public class AddModel : PageModel
    {
        ITeamService teamService;

        Team Team { get; set; }
        public AddModel(ITeamService teamService)
        {
            this.teamService = teamService;
        } 
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Team team) 
        {
            Team = team;
            if(!ModelState.IsValid) { return Page(); }
            Team newTeam = await teamService.AddAsync(team);
            return RedirectToAction("/Team/Index"); 
        }
    }
}
