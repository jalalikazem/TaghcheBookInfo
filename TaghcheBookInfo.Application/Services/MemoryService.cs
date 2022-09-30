using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaghcheBookInfo.Application.Common;

namespace TaghcheBookInfo.Application.Services
{
    public class MemoryService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public object? GetBook(int id)
        {
            if (_memoryCache.TryGetValue(id.ToString(), out object value))
                return value;
            else
                return null;
        }

        public void SetBook(int id, object book)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(Constants.MemoryTimeSeconds),
            };
            _memoryCache.Set(id.ToString(), book, cacheExpiryOptions);
        }
    }
}
