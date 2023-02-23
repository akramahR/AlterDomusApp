using AlterDomusApp.Core.Interfaces.Infrastructure.Github;
using AlterDomusApp.Core.Interfaces.Services;
using AlterDomusApp.Core.Models.DTOs;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AlterDomusApp.Core.Services
{
    /// <summary>
    /// Service that contains all business logic of our app related to github
    /// </summary>
    public class GitHubService : IGitHubService
    {
        private readonly IGithubResources _userProfileGithub;
        private readonly IMapper _mapper;
        private readonly ILogger<GitHubService> _logger;
        public GitHubService(IGithubResources userProfileGithub, IMapper mapper, ILogger<GitHubService> logger)
        {
            _userProfileGithub = userProfileGithub;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Get the required github user information
        /// </summary>
        /// <param name="userLogin">github user</param>
        /// <returns>github user information</returns>
        public async Task<UserGithubDTO> GetUserDataAsync(string userLogin)
        {
            _logger.LogInformation("executing in GetUserDataAsync");
            // Create and start the tasks.
            var reposTask = _userProfileGithub.GetUserRepositoriesAsync(userLogin);
            var profileTask = _userProfileGithub.GetUserProfileAsync(userLogin);

            var repos = await reposTask.ConfigureAwait(false) ?? throw new Exception("null repos recieved");
            _logger.LogInformation("repos:" + JsonSerializer.Serialize(repos));

            var profile = await profileTask.ConfigureAwait(false);
            _logger.LogInformation("profile:" + JsonSerializer.Serialize(profile));

            var userDto = _mapper.Map<UserGithubDTO>(profile);
            userDto.RepositoryCount = repos.Count;

            return userDto;

        }
    }
}
