using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDomusApp.Github.Client
{
    public interface IGithubClient
    {
        public Task<T> GetGithubDataAsync<T>(string requestUri) where T : new();
    }
}
