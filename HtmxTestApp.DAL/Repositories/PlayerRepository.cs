using HtmxTestApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HtmxTestApp.DAL.Repositories.IGenericRepository;

namespace HtmxTestApp.DAL.Repositories
{
    public class PlayerRepository : GenericRepository<Player>
    {
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
