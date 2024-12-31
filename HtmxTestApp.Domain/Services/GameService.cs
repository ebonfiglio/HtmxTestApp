using HtmxTestApp.DAL;
using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using System.Linq.Expressions;

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
            Game game = await unitOfWork.GameRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return game;
        }

        public async Task DeleteAsync(Guid id)
        {
            Game game = await unitOfWork.GameRepository.GetByIdAsync(id);
            unitOfWork.GameRepository.Delete(game);
        }

        public List<Game> Find(Expression<Func<Game, bool>> predicate)
        {
            IEnumerable<Game> result = unitOfWork.GameRepository.Find(predicate);
            return result.ToList();
        }

        public List<Game> GetAll()
        {
            IEnumerable<Game> games = unitOfWork.GameRepository.GetAll();
            return games.ToList();
        }

        public async Task<Game> GetAsync(Guid id)
        {
            return await unitOfWork.GameRepository.GetByIdAsync(id);
        }

        public async Task<Game> UpdateAsync(Game entity)
        {
            Game game = await unitOfWork.GameRepository.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return game;
        }
    }
}
