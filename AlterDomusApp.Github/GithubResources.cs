using AlterDomusApp.Core.Interfaces.Infrastructure.Github;
using AlterDomusApp.Core.Models;
using AlterDomusApp.Core.Shared;
using AlterDomusApp.Github.Client;
using AlterDomusApp.Github.Extensions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace AlterDomusApp.Github
{
    /// <summary>
    /// Github Client implementation for communicating with github's rest apis over http.
    /// </summary>
    public class GithubResources: IGithubResources
    {
        private readonly IGithubClient _githubClient;

        public GithubResources(IGithubClient githubClient)
        {
            _githubClient = githubClient;
        }

        public async Task<List<UserFollowersGithub>> GetUserFollowersAsync(string userLogin)
        {
            var requestUri = "users/" + userLogin + "/followers";
            var userFollowers = await _githubClient.GetGithubDataAsync<List<UserFollowersGithub>>(requestUri);
            return userFollowers;
        }

        public async Task<UserProfileGithub> GetUserProfileAsync(string userLogin)
        {
            var requestUri = "users/" + userLogin;
            var userProfile = await _githubClient.GetGithubDataAsync<UserProfileGithub>(requestUri);
            return userProfile;
        }

        public async Task<List<UserReposGithub>> GetUserRepositoriesAsync(string userLogin)
        {
            var requestUri = "users/" + userLogin + "/repos";
            var userRepos = await _githubClient.GetGithubDataAsync<List<UserReposGithub>>(requestUri);
            return userRepos;
        }
    }
}