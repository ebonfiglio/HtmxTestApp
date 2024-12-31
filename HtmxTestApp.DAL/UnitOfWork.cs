using HtmxTestApp.DAL.Repositories;
using HtmxTestApp.Shared.Entities;

namespace HtmxTestApp.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Player> PlayerRepository { get; }
        IRepository<Position> PositionRepository { get; }
        IRepository<Team> TeamRepository { get; }
        IRepository<GameLog> GameLogRepository { get; }
        IRepository<Game> GameRepository { get; }
        IRepository<Country> CountryRepository { get; }

        Task SaveChangesAsync();
        void ClearChangeTracker();
    }
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private bool _disposed;
        private IRepository<Player> _playerRepository;
        public IRepository<Player> PlayerRepository => _playerRepository ??= new PlayerRepository(context);

        private IRepository<Position> _positionRepository;
        public IRepository<Position> PositionRepository => _positionRepository ??= new PositionRepository(context);

        private IRepository<Team> _teamRepository;
        public IRepository<Team> TeamRepository => _teamRepository ??= new TeamRepository(context);

        private IRepository<GameLog> _gameLogRepository;
        public IRepository<GameLog> GameLogRepository => _gameLogRepository ??= new GameLogRepository(context);

        private IRepository<Game> _gameRepository;
        public IRepository<Game> GameRepository => _gameRepository ??= new GameRepository(context);

        private IRepository<Country> _countryRepository;
        public IRepository<Country> CountryRepository => _countryRepository ??= new CountryRepository(context);

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void ClearChangeTracker()
        {
            context.ChangeTracker.Clear();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
