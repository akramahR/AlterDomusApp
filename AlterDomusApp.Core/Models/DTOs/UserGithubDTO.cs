using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AlterDomusApp.Core.Models.DTOs
{
    public class UserGithubDTO
    {
        [JsonPropertyName("login")]
        public string? Login { get; set; }
        [JsonPropertyName("company")]
        public string? Company { get; set; }
        [JsonPropertyName("bio")]
        public string? Bio { get; set; }
        [JsonPropertyName("location")]
        public string? Location { get; set; }
        [JsonPropertyName("avatarUrl")]
        public string? AvatarUrl { get; set; }
        [JsonPropertyName("repositoryCount")]
        public int RepositoryCount { get; set; }
        [JsonPropertyName("followersCount")]
        public int FollowersCount { get; set; }
    }
}
