using HtmxTestApp.DAL.Repositories;
using HtmxTestApp.DAL;
using HtmxTestApp.Domain.Services.Contracts;
using HtmxTestApp.Domain.Services;
using HtmxTestApp.Shared.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
           .Build();

var defaultConnectionString = config.GetConnectionString("Default");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(defaultConnectionString));

// Add services to the container.
builder.Services.AddRazorPages();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAll");

app.Run();
