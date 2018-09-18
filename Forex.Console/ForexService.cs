using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Forex.Service.Model;
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

        public static async Task<IEnumerable<Quote>> GetQuotes(string apiKey, string[] pairs)
        {
            var pairsString = string.Join(",", pairs);
            var uri = $"https://forex.1forge.com/1.0.3/quotes?pairs={pairsString}&api_key={apiKey}";
            var httpResponseMessage = await httpClient.GetAsync(uri);
            httpResponseMessage.EnsureSuccessStatusCode();

            var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            var quotes = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Quote>>(jsonResponse));
            return quotes;
        }
    }
}