using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;

namespace ActiveSupport
{


    public interface ICache
    {
        void Cache<T>(string key, TimeSpan lifeTime, T val);

        void Cache<T>(string key, T val);

        bool IsCached(string key);

        void Remove(string key);

        void Clear();

        T GetItem<T>(string key);

    }


    public class MemCache : ICache
    {
        private string _region = Guid.NewGuid().ToString();
        private MemoryCache _memoryCache;
        public MemCache()
        {
            _memoryCache = new MemoryCache(_region);
        }


        protected static object _syncObj = 0;
        protected static readonly TimeSpan CACHE_DEFAULT_EXPR_TIME = TimeSpan.FromDays(1);

        public void Clear()
        {
            var keys = _memoryCache.Select(x => x.Key);
            foreach (var key in keys)
                _memoryCache.Remove(key);
        }

        public T GetItem<T>(string key)
        {
            if (IsCached(key))
                return (T)_memoryCache[key];
            return default(T);
        }

        public bool IsCached(string key) =>
            _memoryCache.Contains(key ?? string.Empty);

        public void Remove(string key)
        {
            if (IsCached(key))
                _memoryCache.Remove(key);
        }

        public void Cache<T>(string key, TimeSpan timeSpan, T value)
        {
            if (IsCached(key))
                return;

            var policy = new CacheItemPolicy { SlidingExpiration = timeSpan };
            _memoryCache.Add(key, value, policy);
        }

        public void Cache<T>(string key, T value) =>
            Cache(key, timeSpan: CACHE_DEFAULT_EXPR_TIME, value);

        public interface ICacheClosure
        {
            T Cache<T>(string key, TimeSpan lifeTime, Func<T> funcToCache);

            T Cache<T>(string key, Func<T> funcToCache);

        }


    }








}