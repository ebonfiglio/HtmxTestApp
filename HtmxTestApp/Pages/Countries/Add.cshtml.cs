using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxTestApp.Pages.Countries
{
    public class AddModel : PageModel
    {
        ICountryService countryService;

        Country Country { get; set; }
        public AddModel(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(Country country)
        {
            Country = country;
            if (!ModelState.IsValid) { return Page(); }
            Country newCountry = await countryService.AddAsync(country);
            return RedirectToPage("/Countries/Index");
        }
    }
}
