using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CatFact.Models;
using CatFact.Services;
using Xunit;


namespace CatFact.Tests
{
    class MockHttpHandler : HttpMessageHandler
    {
        readonly string _json;

        public MockHttpHandler(string json)
        {
            _json = json;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken ct
        )
        {
            var msg = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(_json)
            };

            return Task.FromResult(msg);
        }
    }

    public class FactServiceTest
    {
        [Fact]
        public async Task GetTaskAsync_ParsesJsonToFact()
        {
            var fakeJson = @"{""fact"":""Cats purr at 26 Hz. "", ""length"" : 18}";
            var handler = new MockHttpHandler(fakeJson);
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://catfact.ninja/")
            };
            var factService = new FactService(client);

            var fact = await factService.GetFactAsync();

            Assert.NotNull(fact);
            Assert.Equal("Cats purr at 26 Hz. ", fact.Text);
            Assert.Equal(18, fact.Length);
        }
    }
}