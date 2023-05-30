using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Sport.DataAccess.Models;
using Sport.DataTransfer.Dtos;
using Sport.DataTransfer.Requests;

namespace Sport.Business.Mappings
{
    public class UserMappingProfile: Profile
    {
        public UserMappingProfile()
        {
            CreateMap<SignUpRequest, ApplicationUser>();
            CreateMap<ApplicationUser, UserInfoDto>();
        }
    }
}
