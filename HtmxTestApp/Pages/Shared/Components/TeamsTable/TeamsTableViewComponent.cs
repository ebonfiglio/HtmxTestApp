using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.Pages.Shared.Components.TeamsTable
{
    public class TeamsTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Team> teams)
        {
            if (teams is null) teams = new List<Team>();
            return View(teams);
        }
    }
}
