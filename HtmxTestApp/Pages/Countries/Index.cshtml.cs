using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HtmxTestApp.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly ICountryService countryService;

        public List<Country> Countries = new();
        public IndexModel(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        public void OnGet()
        {
            Countries = countryService.GetAll();
        }
    }
}
