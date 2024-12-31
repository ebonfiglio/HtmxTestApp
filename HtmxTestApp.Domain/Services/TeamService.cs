using HtmxTestApp.DAL;
using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
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
            await unitOfWork.SaveChangesAsync();
            return team;
        }

        public async Task DeleteAsync(Guid id)
        {
            Team team = await unitOfWork.TeamRepository.GetByIdAsync(id);
            unitOfWork.TeamRepository.Delete(team);
        }

        public List<Team> Find(Expression<Func<Team, bool>> predicate)
        {
            IEnumerable<Team> result = unitOfWork.TeamRepository.Find(predicate);
            return result.ToList();
        }

        public List<Team> GetAll()
        {
            IEnumerable<Team> teams = unitOfWork.TeamRepository.GetAll();
            return teams.ToList();
        }

        public async Task<Team> GetAsync(Guid id)
        {
            return await unitOfWork.TeamRepository.GetByIdAsync(id);
        }

        public async Task<Team> UpdateAsync(Team entity)
        {
            Team team = await unitOfWork.TeamRepository.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return team;
        }
    }
}
