using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using PSL.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PSL.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        #region Private Properties
        private readonly IMemoryCache _cache;
        #endregion

        #region Constructors
        public MemoryCacheManager()
        {
            _cache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        #endregion

        #region Methods
        public T Get<T>(string key) => _cache.Get<T>(key);

        public object Get(string key) => _cache.Get(key);

        public void Add(string key, object value, int duration) => _cache.Set(key, value, TimeSpan.FromMinutes(duration));

        public bool IsAddedBefore(string key) => _cache.TryGetValue(key, out _);

        public void Remove(string key) => _cache.Remove(key);

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            if (cacheEntriesCollectionDefinition != null)
            {
                var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;

                List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

                foreach (var cacheItem in cacheEntriesCollection)
                {
                    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                    cacheCollectionValues.Add(cacheItemValue);
                }

                var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
                keysToRemove.ForEach(k => _cache.Remove(k));
            }
        }
        #endregion
    }
}
