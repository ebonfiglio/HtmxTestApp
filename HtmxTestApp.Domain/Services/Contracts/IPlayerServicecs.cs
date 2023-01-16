using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmxTestApp.Domain.Services.Contracts
{
    public interface IRoutineService : IGenericService<RoutineRequest, RoutineResponse, Routine, Guid>
    {
    }
}
