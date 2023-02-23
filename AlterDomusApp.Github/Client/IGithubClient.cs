using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDomusApp.Github.Client
{
    /// <summary>
    /// This interface is used to make requests to github api
    /// </summary>
    public interface IGithubClient
    {
        /// <summary>
        /// This method fetches the resource on specified Url and returns the response as T
        /// </summary>
        /// <typeparam name="T">The type response should be deserialised to</typeparam>
        /// <param name="requestUri">the location of the resource that needs to be fetched</param>
        /// <returns>response from get request as T</returns>
        public Task<T?> GetGithubDataAsync<T>(string requestUri) where T : new();
    }
}
