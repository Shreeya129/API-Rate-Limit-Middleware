namespace RateLimiterMiddleware.Models
{
    public class RateLimitOptions
    {
        public int MaxRequests { get; set; }              // Max allowed requests
        public int TimeWindowInSeconds { get; set; }      // Time window for tracking
    }
}
