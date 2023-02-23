using AlterDomusApp.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlterDomusApp.Github.Client
{
    public class GithubClient : IGithubClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GithubClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> GetGithubDataAsync<T>(string requestUri) where T : new()
        {
            var httpResponse = await _httpClientFactory
                .CreateClient(HttpClientNames.Github)
                .GetAsync(requestUri);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(httpResponse.ReasonPhrase, null, httpResponse.StatusCode);
            }

            var res = await httpResponse.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<T>(res);

            return data;
        }
    }
}
