
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaghcheBookInfo.Application.Services
{
    public class TaghcheApiService
    {
        public TaghcheApiService()
        {
        }

        public async Task<object> GetBook(int id)
        {
            var options = new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var url = string.Format("https://get.taaghche.com/v2/book/{0}", id);
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<object>(responseString);
                return result;
            }
        }
    }
}
