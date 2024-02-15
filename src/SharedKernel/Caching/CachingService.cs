using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Net6StudyCase.SharedKernel.Caching
{
    public class CachingService : ICachingService
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _options;

        public CachingService(IDistributedCache cache)
        {
            _cache = cache;
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(15),
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var value = await _cache.GetStringAsync(key);
            return value is null ? default : JsonSerializer.Deserialize<T>(value);
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(string key)
        {
            await _cache.RefreshAsync(key);

            var result = await _cache.GetStringAsync(key);
            if (result is null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<IEnumerable<T>>(result);
        }

        public async Task SetAsync<T>(string key, T value)
        {
            var serializedValue = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, serializedValue, _options);
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }

        public async Task SetAsync(string key, string value)
        {
            await _cache.SetStringAsync(key, value, _options);
        }
    }
}
