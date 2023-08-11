using HtmxTestApp.Blazor;
using HtmxTestApp.Blazor.Services.Teams;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddHttpClient<ITeamsApiService, TeamsApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7141");
});

await builder.Build().RunAsync();
