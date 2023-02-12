using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.Pages.Shared.Components.TeamsForm
{
    public class TeamsFormViewComponent : ViewComponent
    {
        ITeamService teamService;
        public TeamsFormViewComponent(ITeamService teamService)
        {
            this.teamService= teamService;
        }
        public async Task<IViewComponentResult> InvokeAsync(Guid? id)
        {
            if (id is null) return View(new Team());

            Team team = await teamService.GetAsync(id.Value);
            return View(team);
        }
    }
}
