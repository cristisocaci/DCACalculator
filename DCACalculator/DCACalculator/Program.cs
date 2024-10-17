using DCACalculator;
using DCACalculator.Components;
using DCACalculator.Services;
using DCACalculator.Utils;
using MudBlazor.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<DCAContext>();
builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.Configure<CoinMarketCapApiOptions>(builder.Configuration.GetSection(CoinMarketCapApiOptions.CoinMarketCapApi));
builder.Services.AddHttpClient<CoinMarketCapApi>();
builder.Services.AddScoped<DCAInvestmentPlanService>();
builder.Services.AddMemoryCache();

builder.Services.AddMudServices();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
