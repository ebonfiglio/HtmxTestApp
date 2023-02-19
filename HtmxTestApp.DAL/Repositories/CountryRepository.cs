using HtmxTestApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HtmxTestApp.DAL.Repositories.IGenericRepository;

namespace HtmxTestApp.DAL.Repositories
{
    internal class CountryRepository : GenericRepository<Country>
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
