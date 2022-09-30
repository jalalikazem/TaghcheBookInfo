using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaghcheBookInfo.Application.Services
{
    public class RedisService
    {
        private readonly IDistributedCache _distributedCache;
        public RedisService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<object?> GetBook(int id)
        {
            var book = await _distributedCache.GetAsync(id.ToString());
            if (book == null)
                return null;
            else
            {
                var bookString = Encoding.ASCII.GetString(book);
                return JsonSerializer.Deserialize<object>(bookString, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
            }
        }
        public async Task SetBook(int id, object book)
        {
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(2)).SetSlidingExpiration(TimeSpan.FromMinutes(1));
            var jsonBook = JsonSerializer.Serialize(book);
            await _distributedCache.SetAsync(id.ToString(), Encoding.ASCII.GetBytes(jsonBook), options);

        }
    }
}
