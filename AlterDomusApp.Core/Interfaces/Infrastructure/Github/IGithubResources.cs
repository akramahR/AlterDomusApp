using AlterDomusApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDomusApp.Core.Interfaces.Infrastructure.Github
{
    public interface IGithubResources
    {
        Task<UserProfileGithub> GetUserProfileAsync(string userLogin);
        Task<List<UserFollowersGithub>> GetUserFollowersAsync(string userLogin);
        Task<List<UserReposGithub>> GetUserRepositoriesAsync(string userLogin);
    }
}
