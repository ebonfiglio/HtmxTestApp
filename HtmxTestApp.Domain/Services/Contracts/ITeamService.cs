using HtmxTestApp.Shared.Entities;

namespace HtmxTestApp.Domain.Services.Contracts
{
    public interface ITeamService : IGenericService<Team, Guid>
    {
        IAsyncEnumerable<Team> GetAllAsyncEnumerable();
    }
}
