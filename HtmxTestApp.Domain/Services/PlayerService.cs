using HtmxTestApp.DAL;

using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
           return await unitOfWork.PlayerRepository.Add(entity); 
        }

        public async Task DeleteAsync(Guid id)
        {
            Player player = await unitOfWork.PlayerRepository.Get(id);
            await unitOfWork.PlayerRepository.Delete(player);
        }

        public async Task<IEnumerable<Player>> FindAsync(Expression<Func<Player, bool>> predicate)
        {
            IEnumerable<Player> result =  await unitOfWork.PlayerRepository.Find(predicate);
            return result.ToList();
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            IEnumerable<Player> players = await unitOfWork.PlayerRepository.All();
            return players.ToList();
        }

        public async Task<Player> GetAsync(Guid id)
        {
            return await unitOfWork.PlayerRepository.Get(id);
        }

        public async Task<Player> UpdateAsync(Player entity)
        {
            Player player = await unitOfWork.PlayerRepository.Update(entity);
            await unitOfWork.SaveChanges();
            return player;
        }
    }
}
