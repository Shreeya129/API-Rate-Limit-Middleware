namespace RateLimiterMiddleware.Services
{
    public interface IRateLimitService
    {
        bool IsRequestAllowed(string key);
    }
}
