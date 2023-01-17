using HtmxTestApp.DAL;
using HtmxTestApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HtmxTestApp.Domain.Services
{
    public class TeamService
    {
        private readonly IUnitOfWork unitOfWork;
        public TeamService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Team> AddAsync(Team entity)
        {
            return await unitOfWork.TeamRepository.Add(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            Team team = await unitOfWork.TeamRepository.Get(id);
            await unitOfWork.TeamRepository.Delete(team);
        }

        public async Task<IEnumerable<Team>> FindAsync(Expression<Func<Team, bool>> predicate)
        {
            IEnumerable<Team> result = await unitOfWork.TeamRepository.Find(predicate);
            return result.ToList();
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            IEnumerable<Team> teams = await unitOfWork.TeamRepository.All();
            return teams.ToList();
        }

        public async Task<Team> GetAsync(Guid id)
        {
            return await unitOfWork.TeamRepository.Get(id);
        }

        public async Task<Team> UpdateAsync(Team entity)
        {
            Team team = await unitOfWork.TeamRepository.Update(entity);
            await unitOfWork.SaveChanges();
            return team;
        }
    }
}
