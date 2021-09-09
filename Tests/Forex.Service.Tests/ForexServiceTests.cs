using System;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Forex.Service.Services;
using Xunit;

namespace Forex.Service.Tests
{
    [Trait("Category", "SystemTest")]
    public class ForexServiceTests
    {
        [Fact]
        public async Task ShouldGetQuotes_WithEmptyCurrencyPairs_ThrowsException()
        {
            // Arrange
            var pairs = new string[] { };
            var forexService = new ForexService(new ForexServiceConfiguration());

            // Act
            Func<Task> action = () => forexService.GetQuotesAsync(pairs);

            // Assert
            await action.Should().ThrowAsync<HttpRequestException>();
        }

        [Fact]
        public async Task ShouldGetQuotes_WithCurrencyPairs_CHFUSD()
        {
            // Arrange
            var pairs = new[] { "CHF_USD" };
            var forexService = new ForexService(new ForexServiceConfiguration());

            // Act
            var quotes = await forexService.GetQuotesAsync(pairs);

            // Assert
            quotes.Should().NotBeNullOrEmpty();
        }
    }
}