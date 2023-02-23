using AlterDomusApp.Core.Models.DTOs;
using AlterDomusApp.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDomusApp.Core.Interfaces.Services
{
    public interface IGitHubService
    {
        public Task<UserGithubDTO> GetUserDataAsync(string userLogin);
    }
}
