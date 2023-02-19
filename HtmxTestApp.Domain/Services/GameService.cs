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
    public class GameService : IGameService
    {
        private readonly IUnitOfWork unitOfWork;
        public GameService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Game> AddAsync(Game entity)
        {
            Game game = await unitOfWork.GameRepository.Add(entity);
            await unitOfWork.SaveChanges();
            return game;
        }

        public async Task DeleteAsync(Guid id)
        {
            Game game = await unitOfWork.GameRepository.Get(id);
            await unitOfWork.GameRepository.Delete(game);
        }

        public async Task<List<Game>> FindAsync(Expression<Func<Game, bool>> predicate)
        {
            IEnumerable<Game> result = await unitOfWork.GameRepository.Find(predicate);
            return result.ToList();
        }

        public async Task<List<Game>> GetAllAsync()
        {
            IEnumerable<Game> games = await unitOfWork.GameRepository.All();
            return games.ToList();
        }

        public async Task<Game> GetAsync(Guid id)
        {
            return await unitOfWork.GameRepository.Get(id);
        }

        public async Task<Game> UpdateAsync(Game entity)
        {
            Game game = await unitOfWork.GameRepository.Update(entity);
            await unitOfWork.SaveChanges();
            return game;
        }
    }
}
