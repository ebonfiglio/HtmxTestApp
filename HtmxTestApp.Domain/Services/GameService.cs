﻿using HtmxTestApp.DAL;
using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Game>> FindAsync(Expression<Func<Game, bool>> predicate)
        {
            IQueryable<Game> result = unitOfWork.GameRepository.Find(predicate);
            return await result.ToListAsync();
        }

        public async Task<List<Game>> GetAllAsync()
        {
            IQueryable<Game> games = unitOfWork.GameRepository.GetAll();
            return await games.ToListAsync();
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
