using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Forex.Service.Model;
using Forex.Service.Services;

namespace Forex.Service.Tests.Stubs
{
    public class FakeForexService : IForexService
    {
        private static readonly Random Rng = new Random();

        public async Task<IEnumerable<QuoteDto>> GetQuotesAsync(string[] pairs)
        {
            var quotes = new List<QuoteDto>();
            foreach (var symbol in pairs)
            {
                var dto = new QuoteDto
                {
                    Symbol = symbol,
                    Price = (decimal)Rng.NextDouble() * Rng.Next(1, 100),
                };
                quotes.Add(dto);
            }

            await Task.Delay(1000);

            return quotes;
        }
    }
}