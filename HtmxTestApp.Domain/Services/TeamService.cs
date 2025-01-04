using HtmxTestApp.DAL;
using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HtmxTestApp.Domain.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork unitOfWork;
        public TeamService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Team> AddAsync(Team entity)
        {
            Team team = await unitOfWork.TeamRepository.AddAsync(entity);
            return team;
        }

        public async Task DeleteAsync(Guid id)
        {
            Team team = await unitOfWork.TeamRepository.GetByIdAsync(id);
            await unitOfWork.TeamRepository.DeleteAsync(team);
        }

        public async Task<List<Team>> FindAsync(Expression<Func<Team, bool>> predicate)
        {
            IQueryable<Team> result = unitOfWork.TeamRepository.Find(predicate);
            return await result.ToListAsync();
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await unitOfWork.TeamRepository.GetAll().ToListAsync();
        }

        public async Task<Team> GetAsync(Guid id)
        {
            return await unitOfWork.TeamRepository.GetByIdAsync(id);
        }

        public async Task<Team> UpdateAsync(Team entity)
        {
            Team team = await unitOfWork.TeamRepository.UpdateAsync(entity);
            return team;
        }
    }
}
