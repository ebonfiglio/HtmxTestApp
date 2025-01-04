using HtmxTestApp.DAL;

using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
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
            return player;
        }

        public async Task DeleteAsync(Guid id)
        {
            Player player = await unitOfWork.PlayerRepository.GetByIdAsync(id);
            await unitOfWork.PlayerRepository.DeleteAsync(player);
        }

        public async Task<List<Player>> FindAsync(Expression<Func<Player, bool>> predicate)
        {
            IQueryable<Player> result = unitOfWork.PlayerRepository.Find(predicate);
            return await result.ToListAsync();
        }

        public async Task<List<Player>> GetAllAsync()
        {
            IQueryable<Player> players = unitOfWork.PlayerRepository.GetAll();
            return await players.ToListAsync();
        }

        public async Task<Player> GetAsync(Guid id)
        {
            return await unitOfWork.PlayerRepository.GetByIdAsync(id);
        }

        public async Task<Player> UpdateAsync(Player entity)
        {
            Player player = await unitOfWork.PlayerRepository.UpdateAsync(entity);
            return player;
        }
    }
}
