using AlterDomusApp.Core.Interfaces.Infrastructure.Github;
using AlterDomusApp.Core.Interfaces.Services;
using AlterDomusApp.Core.Mappings;
using AlterDomusApp.Core.Models.DTOs;
using AlterDomusApp.Core.Services;
using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests
{
    public class Tests
    {
        private IGitHubService gitHubService;
        private Mock<IGithubResources> githubClientMock = new ();
        private Mock<ILogger<GitHubService>> loggerMock = new();
        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<UserGithubProfile>());
            var mapper = config.CreateMapper();

            gitHubService = new GitHubService(githubClientMock.Object, mapper, loggerMock.Object);
        }

        [Test]
        public async Task Test1()
        {
            //ARRANGE
            var userLogin = "testUser";
            //expected result
            var expected = new UserGithubDTO()
            {
                Login = userLogin,
                Company = "TestCompany",
                Bio = "TestBio",
                Location = "TestCity",
                AvatarUrl = "Test.com",
                Following = 3,
                RepositoryCount = 2
            };

            githubClientMock.
                Setup(mock => mock.GetUserRepositoriesAsync(userLogin))
                .ReturnsAsync(new List<AlterDomusApp.Core.Models.UserReposGithub>() 
                { 
                    new AlterDomusApp.Core.Models.UserReposGithub(), 
                    new AlterDomusApp.Core.Models.UserReposGithub()
                });

            githubClientMock.
                Setup(mock => mock.GetUserFollowersAsync(userLogin))
                .ReturnsAsync(new List<AlterDomusApp.Core.Models.UserFollowersGithub>()
                {
                    new AlterDomusApp.Core.Models.UserFollowersGithub(),
                    new AlterDomusApp.Core.Models.UserFollowersGithub(),
                    new AlterDomusApp.Core.Models.UserFollowersGithub(),
                });

            githubClientMock.
                Setup(mock => mock.GetUserProfileAsync(userLogin))
                .ReturnsAsync(new AlterDomusApp.Core.Models.UserProfileGithub()
                {
                    Login= userLogin,
                    Company = "TestCompany",
                    Bio = "TestBio",
                    Location= "TestCity",
                    AvatarUrl="Test.com"
                });

            //ACT
            var res = await gitHubService.GetUserDataAsync(userLogin);

            //ASSERT
            res.Should().BeEquivalentTo(expected);
        }
    }
}