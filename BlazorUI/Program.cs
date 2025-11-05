// #define USE_ELECTRON

using BlazorUI;
using Infrastructure;
using ElectronNET.API;
using App = BlazorUI.Components.App;

var builder = WebApplication.CreateBuilder(args);

#if USE_ELECTRON
builder.WebHost.UseElectron(args);
#endif

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddInfrastructure();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

#if USE_ELECTRON
await app.StartAsync();
await Electron.WindowManager.CreateWindowAsync();
app.WaitForShutdown();
#endif

