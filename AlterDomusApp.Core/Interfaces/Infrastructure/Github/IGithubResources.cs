using AlterDomusApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDomusApp.Core.Interfaces.Infrastructure.Github
{
    /// <summary>
    /// Github resources avaialible .
    /// </summary>
    public interface IGithubResources
    {
        /// <summary>
        /// Get the followers a github user has and their details.
        /// </summary>
        /// <param name="userLogin">user whose followers are needed</param>
        /// <returns>user followers</returns>
        Task<UserProfileGithub?> GetUserProfileAsync(string userLogin);
        /// <summary>
        /// Get the profile details of a github user
        /// </summary>
        /// <param name="userLogin">user whose profile is needed</param>
        /// <returns>user profile</returns>
        Task<List<UserFollowersGithub>?> GetUserFollowersAsync(string userLogin);
        /// <summary>
        /// Get the repositories of a github user
        /// </summary>
        /// <param name="userLogin">user whose repositories are needed</param>
        /// <returns>user repositories</returns>
        Task<List<UserReposGithub>?> GetUserRepositoriesAsync(string userLogin);
    }
}
