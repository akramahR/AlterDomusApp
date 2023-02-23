using AlterDomusApp.Core.Interfaces.Infrastructure.Github;
using AlterDomusApp.Core.Services;
using AlterDomusApp.Core.Shared;
using AlterDomusApp.Github;
using AlterDomusApp.Github.Client;
using Moq;
using Moq.Protected;

namespace UnitTests
{
    public class GithubClientTest
    {
        private IGithubClient githubClient;
        private Mock<IHttpClientFactory> httpClientFactoryMock;
        [SetUp]
        public void Setup()
        {

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            HttpResponseMessage result = new HttpResponseMessage();

            handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Returns(Task.FromResult(result))
            .Verifiable()
            ;

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://www.test.com/")
            };

            var mockHttpClientFactory = new Mock<IHttpClientFactory>();

            mockHttpClientFactory.Setup(_ => _.CreateClient(HttpClientNames.Github)).Returns(httpClient);


            githubClient = new GithubClient(mockHttpClientFactory.Object);
        }

        [Test]
        public async Task Test1()
        {
            //await githubClient.GetGithubDataAsync();
        }
    }
}
