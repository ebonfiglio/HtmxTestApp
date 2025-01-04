using HtmxTestApp.Blazor.Components;
using HtmxTestApp.Blazor.Helpers;
using HtmxTestApp.DAL;
using HtmxTestApp.Domain.Services;
using HtmxTestApp.Domain.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
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


            builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(defaultConnectionString));

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IPlayerService, PlayerService>();
            builder.Services.AddScoped<ITeamService, TeamService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IGameService, GameService>();

            builder.Services.AddScoped<HtmlRenderer>();
            builder.Services.AddScoped<BlazorRenderer>();

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(BlazorWASM.Client._Imports).Assembly);

            app.Run();
        }
    }
}
