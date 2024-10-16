using DCACalculator;
using DCACalculator.Components;
using DCACalculator.Services;
using DCACalculator.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<DCAContext>();
builder.Services.Configure<CoinMarketCapApiOptions>(builder.Configuration.GetSection(CoinMarketCapApiOptions.CoinMarketCapApi));
builder.Services.AddHttpClient<CoinMarketCapApi>();
builder.Services.AddScoped<DCAInvestmentPlanService>();
builder.Services.AddMemoryCache();

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
