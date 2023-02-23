using AlterDomusApp.Core.Models.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;

namespace IntegrationTests
{
    public class GithubControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {

        [Fact]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType()
        {
            var api = new WebApplicationFactory();
            var response = await api.CreateClient().GetAsync("/api/Github?userLogin=akramahR");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task Get_EndpointNotFoundOnInvalidUser()
        {
            var api = new WebApplicationFactory();
            var response = await api.CreateClient().GetAsync("/api/Github?userLogin=adshbsdhvjbdvashj");

            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        [Fact]
        public async Task Get_EndpointContentValid()
        {
            var expected = new UserGithubDTO()
            {
                Login = "akramahR",
                Company = null,
                Bio = null,
                Location = null,
                AvatarUrl = "https://avatars.githubusercontent.com/u/99917829?v=4",
                FollowersCount = 0,
                RepositoryCount = 1
            };
            var api = new WebApplicationFactory();
            var response = await api.CreateClient().GetAsync("/api/Github?userLogin=akramahR");

            var res = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<UserGithubDTO>(res);

            data.Should().BeEquivalentTo(expected);
        }

        //[Theory]
        //[InlineData("/GetWeatherForecast?userLogin=asd")]
        //public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        //{
        //    // Arrange
        //    var client = _factory.CreateClient();

        //    // Act
        //    var response = await client.GetAsync(url);

        //    // Assert
        //    response.EnsureSuccessStatusCode(); // Status Code 200-299
        //    Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
        //}
    }
}