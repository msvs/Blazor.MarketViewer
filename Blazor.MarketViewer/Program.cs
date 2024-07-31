using Blazor.MarketViewer.Components;
using MarketViewer.Application.OrderBookServices;
using MarketViewer.Domain.Abstractions;
using MarketViewer.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IOrderBookService, BinanceOrderBookService>();
builder.Services.AddTransient<IOrderBookLogger, FileOrderBookLogger>();
var app = builder.Build();

// Configure API routes.
app.MapGet("api/orderBook", (ILogger<Program> logger) => "Hello World!");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
