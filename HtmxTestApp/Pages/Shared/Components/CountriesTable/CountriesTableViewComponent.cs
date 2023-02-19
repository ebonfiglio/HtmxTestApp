using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.Pages.Shared.Components.CountriesTable
{
    public class CountriesTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IEnumerable<Country> countries)
        {
            if (countries is null) countries = new List<Country>();
            return View(countries);
        }
    }
}
