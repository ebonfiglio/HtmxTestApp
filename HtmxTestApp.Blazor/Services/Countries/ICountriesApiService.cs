using HtmxTestApp.Shared.Entities;

namespace HtmxTestApp.Blazor.Services.Countries
{
    public interface ICountriesApiService
    {
        Task<List<Country>> GetAllAsync();
    }
}
