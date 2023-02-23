using AlterDomusApp.Core.Services;
using AlterDomusApp.Core.Shared;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlterDomusApp.Github.Client
{
    /// <summary>
    /// Class for communicating with github api using http
    /// </summary>
    public class GithubClient : IGithubClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<GithubClient> _logger;
        public GithubClient(IHttpClientFactory httpClientFactory, ILogger<GithubClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        /// <summary>
        /// Method for fetching data from github's resources available on specified requestUri
        /// </summary>
        /// <typeparam name="T">The type we want response to be returned/deserialised as</typeparam>
        /// <param name="requestUri">the location of the resource we are fetching(base uri is already configured)</param>
        /// <returns>Response from resource as an instance of T</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<T?> GetGithubDataAsync<T>(string requestUri) where T : new()
        {
            var httpResponse = await _httpClientFactory
                .CreateClient(HttpClientNames.Github)
                .GetAsync(requestUri);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new HttpRequestException(httpResponse.ReasonPhrase, null, httpResponse.StatusCode);
            }

            var res = await httpResponse.Content.ReadAsStringAsync();
            _logger.LogInformation("httpResponse content:" + res);

            var data = JsonSerializer.Deserialize<T>(res);

            return data;
        }
    }
}
