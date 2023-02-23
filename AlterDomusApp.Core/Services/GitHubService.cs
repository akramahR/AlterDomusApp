using AlterDomusApp.Core.Interfaces.Infrastructure.Github;
using AlterDomusApp.Core.Interfaces.Services;
using AlterDomusApp.Core.Models.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDomusApp.Core.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly IGithubResources _userProfileGithub;
        private readonly IMapper _mapper;
        public GitHubService(IGithubResources userProfileGithub, IMapper mapper)
        {
            _userProfileGithub = userProfileGithub;
            _mapper = mapper;
        }

        public async Task<UserGithubDTO> GetUserDataAsync(string userLogin)
        {
            // Create and start the tasks.
            var followersTask = _userProfileGithub.GetUserFollowersAsync(userLogin);
            var reposTask = _userProfileGithub.GetUserRepositoriesAsync(userLogin);
            var profileTask = _userProfileGithub.GetUserProfileAsync(userLogin);

            var followers = await followersTask.ConfigureAwait(false);
            var repos = await reposTask.ConfigureAwait(false);
            var profile = await profileTask.ConfigureAwait(false);

            var userDto = _mapper.Map<UserGithubDTO>(profile);
            userDto.RepositoryCount = repos.Count;
            userDto.FollowersCount = followers.Count;

            return userDto;

        }
    }
}
