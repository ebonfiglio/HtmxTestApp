using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxTestApp.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly ITeamService teamService;

        public List<Team> Teams = new();
        public IndexModel(ITeamService teamService)
        {
            this.teamService = teamService;
        }
        public async Task OnGet()
        {
            Teams = await teamService.GetAllAsync();
        }
    }
}
