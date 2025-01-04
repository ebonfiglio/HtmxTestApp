using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using static HtmxTestApp.DAL.Repositories.IGenericRepository;

namespace HtmxTestApp.DAL.Repositories
{
    public class CountryRepository : GenericRepository<Country>
    {
        public CountryRepository(IDbContextFactory<ApplicationDbContext> _contextFactory) : base(_contextFactory)
        {
        }
    }
}
