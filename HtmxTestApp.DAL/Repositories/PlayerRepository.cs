using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using static HtmxTestApp.DAL.Repositories.IGenericRepository;

namespace HtmxTestApp.DAL.Repositories
{
    public class PlayerRepository : GenericRepository<Player>
    {
        public PlayerRepository(IDbContextFactory<ApplicationDbContext> _contextFactory) : base(_contextFactory)
        {

        }
    }
}
