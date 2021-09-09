using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Forex.Console.Model;
using Newtonsoft.Json;

namespace Forex.Console
{
    public static class ForexService
    {
        private static readonly HttpClient httpClient;

        static ForexService()
        {
            httpClient = new HttpClient();
        }

        public static async Task<IEnumerable<QuoteDto>> GetQuotes(string[] pairs)
        {
            // Send API request
            var pairsString = string.Join(",", pairs);
            var uri = $"https://free.currconv.com/api/v7/convert?q={pairsString}&apiKey=1da6b2cdf62c0e7c15fe";
            var httpResponseMessage = await httpClient.GetAsync(uri);
            httpResponseMessage.EnsureSuccessStatusCode();

            // Read request payload and transform JSON to DTO object
            var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var rootObject = JsonConvert.DeserializeObject<ConvertResponseDto>(jsonResponse);

            var quoteDtos = rootObject.Results.CurrencyList.Select(c =>
            {
                var quoteDto = c.Value.ToObject<QuoteDto>();
                return quoteDto;
            }).ToList();
            return quoteDtos;
        }
    }
}