using AlterDomusApp.Core.Interfaces.Services;
using AlterDomusApp.Core.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AlterDomusAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GithubController : ControllerBase
    {

        private readonly ILogger<GithubController> _logger;
        private readonly IGitHubService _gitHubService;

        public GithubController(ILogger<GithubController> logger, IGitHubService gitHubService)
        {
            _logger = logger;
            _gitHubService = gitHubService;
        }

        [HttpGet(Name = "GetWeatherForecast/{userLogin}")]
        public async Task<UserGithubDTO> GetAsync(string userLogin)
        {
            var result = await _gitHubService.GetUserDataAsync(userLogin);
            _logger.LogInformation("Succesfuly executed the getProfile request");
            return result;
        }
    }
}