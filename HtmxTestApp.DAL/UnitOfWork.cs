using HtmxTestApp.DAL.Repositories;
using HtmxTestApp.Shared.Entities;

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

        Task SaveChanges();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        private IRepository<Player> playerRepository;
        public IRepository<Player> PlayerRepository
        {
            get
            {
                if (playerRepository == null)
                {
                    playerRepository = new PlayerRepository(context);
                }
                return playerRepository;
            }
        }

        private IRepository<Position> positionRepository;
        public IRepository<Position> PositionRepository
        {
            get
            {
                if (positionRepository == null)
                {
                    positionRepository = new PositionRepository(context);
                }
                return positionRepository;
            }
        }

        private IRepository<Team> teamRepository;
        public IRepository<Team> TeamRepository
        {
            get
            {
                if (teamRepository == null)
                {
                    teamRepository = new TeamRepository(context);
                }
                return teamRepository;
            }
        }

        private IRepository<GameLog> gameLogRepository;
        public IRepository<GameLog> GameLogRepository
        {
            get
            {
                if (gameLogRepository == null)
                {
                    gameLogRepository = new GameLogRepository(context);
                }
                return gameLogRepository;
            }
        }

        private IRepository<Game> gameRepository;
        public IRepository<Game> GameRepository
        {
            get
            {
                if (gameRepository == null)
                {
                    gameRepository = new GameRepository(context);
                }
                return gameRepository;
            }
        }

        private IRepository<Country> countryRepository;
        public IRepository<Country> CountryRepository
        {
            get
            {
                if (countryRepository == null)
                {
                    countryRepository = new CountryRepository(context);
                }
                return countryRepository;
            }
        }

        public virtual async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }
    }
}
