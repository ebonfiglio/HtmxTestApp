using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using static HtmxTestApp.DAL.Repositories.IGenericRepository;

namespace HtmxTestApp.DAL.Repositories
{
    public class GameLogRepository : GenericRepository<GameLog>
    {
        public GameLogRepository(IDbContextFactory<ApplicationDbContext> _contextFactory) : base(_contextFactory)
        {
        }
    }
}
