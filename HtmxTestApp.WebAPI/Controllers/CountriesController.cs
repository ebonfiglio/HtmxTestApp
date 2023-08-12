using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HtmxTestApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            List<Country> countries = await _countryService.GetAllAsync();
            return Ok(countries);
        }
    }
}
