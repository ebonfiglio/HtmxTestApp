using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.Pages.Shared.Components.TeamsForm
{
    public class TeamsFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Team team)
        {
            if (team is null) team = new();
            return View(team);
        }
    }
}
