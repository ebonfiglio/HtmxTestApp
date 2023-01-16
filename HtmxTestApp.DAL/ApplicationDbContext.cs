using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HtmxTestApp.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>()
                    .HasOne(p => p.WinningTeam)
                    .WithMany(t => t.WinningGames)
                    .HasForeignKey(m => m.WinningTeamId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Game>()
                    .HasOne(p => p.LosingTeam)
                    .WithMany(t => t.LosingGames)
                    .HasForeignKey(m => m.LosingTeamId)
                    .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<GameLog> GameLogs { get; set; }

    }
}

