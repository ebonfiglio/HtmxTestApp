using HtmxTestApp.Shared.Entities;

namespace HtmxTestApp.Blazor.Services.Teams
{
    public interface ITeamsApiService
    {
        Task<List<Team>> GetAllAsync();
    }
}
