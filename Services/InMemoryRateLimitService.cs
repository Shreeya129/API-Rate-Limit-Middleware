using System.Collections.Concurrent;
using RateLimiterMiddleware.Models;

namespace RateLimiterMiddleware.Services
{
    public class InMemoryRateLimitService : IRateLimitService
    {
        private readonly ConcurrentDictionary<string, List<DateTime>> _requestLogs = new();
        private readonly RateLimitOptions _options;

        public InMemoryRateLimitService(RateLimitOptions options)
        {
            _options = options;
        }

        public bool IsRequestAllowed(string key)
        {
            var now = DateTime.UtcNow;

            _requestLogs.TryGetValue(key, out var timestamps);
            if (timestamps == null)
            {
                timestamps = new List<DateTime>();
                _requestLogs[key] = timestamps;
            }

            // Remove outdated requests
            timestamps.RemoveAll(t => t <= now.AddSeconds(-_options.TimeWindowInSeconds));

            if (timestamps.Count >= _options.MaxRequests)
                return false;

            timestamps.Add(now);
            return true;
        }
    }
}
