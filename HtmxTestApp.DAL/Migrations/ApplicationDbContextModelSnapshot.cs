﻿// <auto-generated />
using System;
using HtmxTestApp.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HtmxTestApp.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LosingTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LosingTeamScore")
                        .HasColumnType("int");

                    b.Property<Guid>("WinningTeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WinningTeamScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LosingTeamId");

                    b.HasIndex("WinningTeamId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.GameLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Rebounds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GameLogs");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.Game", b =>
                {
                    b.HasOne("HtmxTestApp.Shared.Entities.Team", "LosingTeam")
                        .WithMany("LosingGames")
                        .HasForeignKey("LosingTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("HtmxTestApp.Shared.Entities.Team", "WinningTeam")
                        .WithMany("WinningGames")
                        .HasForeignKey("WinningTeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("LosingTeam");

                    b.Navigation("WinningTeam");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.GameLog", b =>
                {
                    b.HasOne("HtmxTestApp.Shared.Entities.Game", "Game")
                        .WithMany("GameLogs")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HtmxTestApp.Shared.Entities.Player", "Player")
                        .WithMany("GameLogs")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.Player", b =>
                {
                    b.HasOne("HtmxTestApp.Shared.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HtmxTestApp.Shared.Entities.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.Game", b =>
                {
                    b.Navigation("GameLogs");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.Player", b =>
                {
                    b.Navigation("GameLogs");
                });

            modelBuilder.Entity("HtmxTestApp.Shared.Entities.Team", b =>
                {
                    b.Navigation("LosingGames");

                    b.Navigation("Players");

                    b.Navigation("WinningGames");
                });
#pragma warning restore 612, 618
        }
    }
}