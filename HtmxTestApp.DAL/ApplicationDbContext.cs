using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                    .HasOne(p => p.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(m => m.HomeTeamId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Game>()
                    .HasOne(p => p.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(m => m.AwayTeamId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Team>()
                    .HasOne(p => p.Country)
                    .WithMany()
                    .HasForeignKey(m => m.CountryId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Player>()
                    .HasOne(p => p.Country)
                    .WithMany()
                    .HasForeignKey(m => m.CountryId)
                    .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<GameLog> GameLogs { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

    }
}

