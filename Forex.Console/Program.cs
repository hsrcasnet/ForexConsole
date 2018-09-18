using System;
using System.Linq;
using System.Threading.Tasks;

namespace Forex.Console
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            const string apiKey = "OLJvKkKByrQEOJoWBmIdlaHfEOaTAyOw";
            var currencyPairs = new[] { "CHFUSD", "USDCHF", "CHFEUR", "EURCHF" };

            do
            {
                System.Console.WriteLine($"GetQuotes @ {DateTime.Now:s}");
                var quotes = (await ForexService.GetQuotes(apiKey, currencyPairs)).ToList();
                foreach (var quote in quotes)
                {
                    System.Console.WriteLine($"Symbol={quote.Symbol}\tPrice={quote.Price:F6}\tBid={quote.Bid:F6}\tAsk={quote.Ask:F6}");
                }

                System.Console.WriteLine("");
            } while (System.Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}