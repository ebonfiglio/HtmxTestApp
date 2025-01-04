using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using static HtmxTestApp.DAL.Repositories.IGenericRepository;

namespace HtmxTestApp.DAL.Repositories
{
    public class PositionRepository : GenericRepository<Position>
    {
        public PositionRepository(IDbContextFactory<ApplicationDbContext> _contextFactory) : base(_contextFactory)
        {
        }
    }
}
