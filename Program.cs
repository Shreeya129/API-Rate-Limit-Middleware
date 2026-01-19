using RateLimiterMiddleware.Models;
using RateLimiterMiddleware.Middleware;
using RateLimiterMiddleware.Services;

var builder = WebApplication.CreateBuilder(args);

// Bind RateLimitOptions from appsettings.json
var rateLimitOptions = builder.Configuration
    .GetSection("RateLimitOptions")
    .Get<RateLimitOptions>();

// Register services
builder.Services.AddSingleton(rateLimitOptions);
builder.Services.AddSingleton<IRateLimitService, InMemoryRateLimitService>();
builder.Services.AddControllers();

var app = builder.Build();

// Use custom rate limiter middleware
app.UseMiddleware<RateLimitingMiddleware>();

app.MapControllers();

app.Run();
