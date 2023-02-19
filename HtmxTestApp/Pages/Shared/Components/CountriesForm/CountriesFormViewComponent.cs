using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.Pages.Shared.Components.CountriesForm
{
    public class CountriesFormViewComponent: ViewComponent
    {
        ICountryService countryService;
        public CountriesFormViewComponent(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        public async Task<IViewComponentResult> InvokeAsync(Guid? id)
        {
            if (id is null) return View(new Country());

            Country country = await countryService.GetAsync(id.Value);
            return View(country);
        }
    }
}
