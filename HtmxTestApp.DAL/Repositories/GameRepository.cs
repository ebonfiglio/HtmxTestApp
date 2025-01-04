using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using static HtmxTestApp.DAL.Repositories.IGenericRepository;

namespace HtmxTestApp.DAL.Repositories
{
    public class GameRepository : GenericRepository<Game>
    {
        public GameRepository(IDbContextFactory<ApplicationDbContext> contextFactory) : base(contextFactory)
        {
        }
    }
}
