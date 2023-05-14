using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
