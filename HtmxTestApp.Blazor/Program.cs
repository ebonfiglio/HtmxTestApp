using HtmxTestApp.Blazor.Components;
using HtmxTestApp.DAL;
using HtmxTestApp.DAL.Repositories;
using HtmxTestApp.Domain.Services;
using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace HtmxTestApp.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
           .Build();

            var defaultConnectionString = config.GetConnectionString("Default");

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseLazyLoadingProxies().UseSqlServer(defaultConnectionString));

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddScoped<IRepository<Player>, PlayerRepository>();
            builder.Services.AddScoped<IRepository<Team>, TeamRepository>();
            builder.Services.AddScoped<IRepository<Game>, GameRepository>();
            builder.Services.AddScoped<IRepository<GameLog>, GameLogRepository>();
            builder.Services.AddScoped<IRepository<Position>, PositionRepository>();
            builder.Services.AddScoped<IRepository<Country>, CountryRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IPlayerService, PlayerService>();
            builder.Services.AddScoped<ITeamService, TeamService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IGameService, GameService>();

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode();

            app.Run();
        }
    }
}
