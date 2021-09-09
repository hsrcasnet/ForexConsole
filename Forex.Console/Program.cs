using System;
using System.Linq;
using System.Threading.Tasks;

namespace Forex.Console
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var currencyPairs = new[] { "CHF_EUR", "EUR_CHF" };

            do
            {
                System.Console.WriteLine($"GetQuotes @ {DateTime.Now:s}");
                var quotes = (await ForexService.GetQuotes(currencyPairs)).ToList();
                foreach (var quote in quotes)
                {
                    System.Console.WriteLine($"Symbol={quote.Symbol}\tPrice={quote.Price:F6}");
                }

                System.Console.WriteLine();
            } while (System.Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}