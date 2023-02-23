using AlterDomusApp.Core.Models;
using AlterDomusApp.Core.Models.DTOs;
using AlterDomusApp.Core.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlterDomusApp.Core.Mappings
{
    public class UserGithubProfile: Profile
    {
        public UserGithubProfile()
        {
            CreateMap<UserProfileGithub, UserGithubDTO>();
        }
    }
}
