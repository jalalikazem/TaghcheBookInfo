using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaghcheBookInfo.Application.Common;
using TaghcheBookInfo.Application.Services;

namespace TaghcheBookInfo.Application
{
    public class GetBookHandler
    {
        private readonly MemoryService _memoryService;
        private readonly RedisService _redisService;
        private readonly TaghcheApiService _taghcheApiService;

        public GetBookHandler(MemoryService memoryService, RedisService redisService, TaghcheApiService taghcheApiService)
        {
            _memoryService = memoryService;
            _redisService = redisService;
            _taghcheApiService = taghcheApiService;
        }

        public async Task<GeneralResponse> GetBook(int id)
        {
            object? book = _memoryService.GetBook(id);
            if (book is not null)
                return GeneralResponse.Success(book, "From Memory");

            book = await _redisService.GetBook(id);
            if (book is not null)
            {
                _memoryService.SetBook(id, book);
                return GeneralResponse.Success(book, "From Redis");
            }

            book = await _taghcheApiService.GetBook(id);
            if (book is null)
                return GeneralResponse.Failed("Not Found!");

            _memoryService.SetBook(id, book);
            await _redisService.SetBook(id, book);
            return GeneralResponse.Success(book, "from API");
        }
    }
}
