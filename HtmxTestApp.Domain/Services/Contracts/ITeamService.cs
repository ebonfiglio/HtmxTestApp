using HtmxTestApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmxTestApp.Domain.Services.Contracts
{
    public interface ITeamService : IGenericService<Team, Guid>
    {
    }
}
