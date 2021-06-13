using System;
using System.Runtime.Caching;

namespace CacheablePostcodeLookup.Cache
{
    public class SimpleCache
    {
        private readonly MemoryCache _cache = MemoryCache.Default;

        public void Set(string name, object data, int cacheTimeInMinutes)
        {
            var cacheItemPolicy = new CacheItemPolicy {SlidingExpiration = new TimeSpan(0,0,cacheTimeInMinutes)};
            _cache.Set(name, data, cacheItemPolicy);
        }

        public T Get<T>(string name) where T:class
        {
            return _cache.Get(name) as T;
        }
    }
}
