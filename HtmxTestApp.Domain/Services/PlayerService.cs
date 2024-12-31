using HtmxTestApp.DAL;

using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using System.Linq.Expressions;

namespace HtmxTestApp.Domain.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork unitOfWork;
        public PlayerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Player> AddAsync(Player entity)
        {
            Player player = await unitOfWork.PlayerRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return player;
        }

        public async Task DeleteAsync(Guid id)
        {
            Player player = await unitOfWork.PlayerRepository.GetByIdAsync(id);
            unitOfWork.PlayerRepository.Delete(player);
        }

        public List<Player> Find(Expression<Func<Player, bool>> predicate)
        {
            IEnumerable<Player> result = unitOfWork.PlayerRepository.Find(predicate);
            return result.ToList();
        }

        public List<Player> GetAll()
        {
            IEnumerable<Player> players = unitOfWork.PlayerRepository.GetAll();
            return players.ToList();
        }

        public async Task<Player> GetAsync(Guid id)
        {
            return await unitOfWork.PlayerRepository.GetByIdAsync(id);
        }

        public async Task<Player> UpdateAsync(Player entity)
        {
            Player player = await unitOfWork.PlayerRepository.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return player;
        }
    }
}
