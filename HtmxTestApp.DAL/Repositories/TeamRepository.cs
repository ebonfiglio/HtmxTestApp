using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using static HtmxTestApp.DAL.Repositories.IGenericRepository;

namespace HtmxTestApp.DAL.Repositories
{
    public class TeamRepository : GenericRepository<Team>
    {
        public TeamRepository(IDbContextFactory<ApplicationDbContext> _contextFactory) : base(_contextFactory)
        {
        }
    }
}
