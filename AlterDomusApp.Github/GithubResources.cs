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
    /// Github resources avaialible .
    /// </summary>
    public class GithubResources: IGithubResources
    {
        private readonly IGithubClient _githubClient;

        public GithubResources(IGithubClient githubClient)
        {
            _githubClient = githubClient;
        }
        /// <summary>
        /// Get the followers a github user has and their details.
        /// </summary>
        /// <param name="userLogin">user whose followers are needed</param>
        /// <returns>user followers</returns>
        public async Task<List<UserFollowersGithub>?> GetUserFollowersAsync(string userLogin)
        {
            var requestUri = "users/" + userLogin + "/followers";
            var userFollowers = await _githubClient.GetGithubDataAsync<List<UserFollowersGithub>>(requestUri);
            return userFollowers;
        }
        /// <summary>
        /// Get the profile details of a github user
        /// </summary>
        /// <param name="userLogin">user whose profile is needed</param>
        /// <returns>user profile</returns>
        public async Task<UserProfileGithub?> GetUserProfileAsync(string userLogin)
        {
            var requestUri = "users/" + userLogin;
            var userProfile = await _githubClient.GetGithubDataAsync<UserProfileGithub>(requestUri);
            return userProfile;
        }
        /// <summary>
        /// Get the repositories of a github user
        /// </summary>
        /// <param name="userLogin">user whose repositories are needed</param>
        /// <returns>user repositories</returns>
        public async Task<List<UserReposGithub>?> GetUserRepositoriesAsync(string userLogin)
        {
            var requestUri = "users/" + userLogin + "/repos";
            var userRepos = await _githubClient.GetGithubDataAsync<List<UserReposGithub>>(requestUri);
            return userRepos;
        }
    }
}