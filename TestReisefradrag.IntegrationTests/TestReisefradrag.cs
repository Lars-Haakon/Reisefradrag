using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reisefradrag.Dto;
using System.Net.Http.Headers;
using System.Text.Json;

namespace TestReisefradrag.IntegrationTests
{
    [TestClass]
    public class TestReisefradrag
    {
        private static WebApplicationFactory<Program> _factory;
        private static HttpClient _httpClient;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _factory = new WebApplicationFactory<Program>();
            _httpClient = _factory.CreateClient();
        }

        [TestMethod]
        public async Task BasicRequest_ReturnsEmptyReisefradrag()
        {
            var request = new ReisefradragRequest
            {
                arbeidsreiser = new(),
                besoeksreiser = new(),
                utgifterBomFergeEtc = 0
            };

            HttpContent content = new StringContent(JsonSerializer.Serialize(request), new MediaTypeHeaderValue("application/json"));

            var response = await _httpClient.PostAsync("/Reisefradrag", content);
            var responseContent = JsonSerializer.Deserialize<ReisefradragResponse>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(0M, responseContent.reisefradrag);
        }

        [TestMethod]
        public async Task ExampleRequest_ReturnsCorrectfradrag()
        {
            var request = new ReisefradragRequest
            {
                arbeidsreiser = new()
                {
                    new Arbeidsreise { km=91, antall=180 },
                    new Arbeidsreise { km=378, antall=4 },
                },
                besoeksreiser = new()
                {
                    new Besoeksreise { km=580, antall=4 },
                },
                utgifterBomFergeEtc = 4850
            };

            HttpContent content = new StringContent(JsonSerializer.Serialize(request), new MediaTypeHeaderValue("application/json"));

            var response = await _httpClient.PostAsync("/Reisefradrag", content);
            var responseContent = JsonSerializer.Deserialize<ReisefradragResponse>(await response.Content.ReadAsStringAsync());

            Assert.AreEqual(13168M, responseContent.reisefradrag);
        }
    }
}
