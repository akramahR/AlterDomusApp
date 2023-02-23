using AlterDomusApp.Core.Models.DTOs;
using AlterDomusApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDomusApp.Core.Interfaces.Services
{
    /// <summary>
    /// Service that contains all business logic of our app related to github
    /// </summary>
    public interface IGitHubService
    {
        /// <summary>
        /// Get the required github user information
        /// </summary>
        /// <param name="userLogin">github user</param>
        /// <returns>github user information</returns>
        public Task<UserGithubDTO> GetUserDataAsync(string userLogin);
    }
}
