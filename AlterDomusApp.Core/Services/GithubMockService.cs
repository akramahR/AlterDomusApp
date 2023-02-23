using AlterDomusApp.Core.Interfaces.Services;
using AlterDomusApp.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDomusApp.Core.Services
{
    /// <summary>
    /// Use only for testing purposes. Switch to this service with DI for testing If github api limit has been reached 
    /// </summary>
    internal class GithubMockService : IGitHubService
    {
        public async Task<UserGithubDTO> GetUserDataAsync(string userLogin)
        {
            Random r = new Random();

            var userGithubDTO = new UserGithubDTO() 
            {
                AvatarUrl = "https://picsum.photos/200/200",
                Bio = "Software Engineer-C#|JS|TS-Mock orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.",
                Location= "london",
                Login= userLogin,
                FollowersCount= r.Next(0, 10),
                RepositoryCount= r.Next(0, 10),
                Company = "Alter Domus"
            };
            return userGithubDTO;
        }
    }
}
