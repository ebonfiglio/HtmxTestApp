using HtmxTestApp.DAL.Repositories;
using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace HtmxTestApp.DAL
{
    public interface IUnitOfWork
    {
        IRepository<Player> PlayerRepository { get; }
        IRepository<Position> PositionRepository { get; }
        IRepository<Team> TeamRepository { get; }
        IRepository<GameLog> GameLogRepository { get; }
        IRepository<Game> GameRepository { get; }
        IRepository<Country> CountryRepository { get; }
    }
    public class UnitOfWork(IDbContextFactory<ApplicationDbContext> _contextFactory) : IUnitOfWork
    {
        private bool _disposed;
        private IRepository<Player> _playerRepository;
        public IRepository<Player> PlayerRepository => _playerRepository ??= new PlayerRepository(_contextFactory);

        private IRepository<Position> _positionRepository;
        public IRepository<Position> PositionRepository => _positionRepository ??= new PositionRepository(_contextFactory);

        private IRepository<Team> _teamRepository;
        public IRepository<Team> TeamRepository => _teamRepository ??= new TeamRepository(_contextFactory);

        private IRepository<GameLog> _gameLogRepository;
        public IRepository<GameLog> GameLogRepository => _gameLogRepository ??= new GameLogRepository(_contextFactory);

        private IRepository<Game> _gameRepository;
        public IRepository<Game> GameRepository => _gameRepository ??= new GameRepository(_contextFactory);

        private IRepository<Country> _countryRepository;
        public IRepository<Country> CountryRepository => _countryRepository ??= new CountryRepository(_contextFactory);
    }
}
