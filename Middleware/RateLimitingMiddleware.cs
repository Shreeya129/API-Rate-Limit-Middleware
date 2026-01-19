using Microsoft.AspNetCore.Http;
using RateLimiterMiddleware.Services;

namespace RateLimiterMiddleware.Middleware
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRateLimitService _rateLimitService;

        public RateLimitingMiddleware(RequestDelegate next, IRateLimitService rateLimitService)
        {
            _next = next;
            _rateLimitService = rateLimitService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var key = context.Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(key))
                key = context.Connection.RemoteIpAddress?.ToString();

            if (!_rateLimitService.IsRequestAllowed(key))
            {
                context.Response.StatusCode = 429; // Too Many Requests
                await context.Response.WriteAsync("Too many requests. Please try again later.");
                return;
            }

            await _next(context);
        }
    }
}
