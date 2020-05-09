using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CesarBmx.Caching.Extensions
{
    public static class CacheExtensions
    {
        public static async Task<TResponse> GetCache<TResponse>(this IDistributedCache cache, string key, Task<TResponse> task, int absoluteExpirationInSeconds)
        {
            var cacheValue = await cache.GetAsync(key);
            TResponse response;
            if (cacheValue == null)
            {
                response = await task;
                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(absoluteExpirationInSeconds)
                };
                var serializedResponse = JsonConvert.SerializeObject(response);
                var responseInBytes = Encoding.UTF8.GetBytes(serializedResponse);
                await cache.SetAsync(key, responseInBytes, options);
            }
            else
            {
                var serializedResponse = Encoding.UTF8.GetString(cacheValue);
                response = JsonConvert.DeserializeObject<TResponse>(serializedResponse);

            }
            return response;
        }
        public static async Task<TResponse> GetCache<TResponse>(this IDistributedCache cache, string key, Task<TResponse> task, int absoluteExpirationInSeconds, Type type, params string[] parameters)
        {
            key = type.FullName + "." + key;
            foreach (var parameter in parameters)
            {
                key += "_" + parameter;
            }
            return await GetCache(cache, key, task, absoluteExpirationInSeconds);
        }
    }
}
