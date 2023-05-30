using Microsoft.AspNetCore.Identity;
using Sport.DataAccess.Models;
using Sport.DataTransfer.Dtos;
using Sport.DataTransfer.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport.Business.Servises.Interfaces
{
    public interface IIdentityManager
    {
        Task<ApplicationUser> RegisterUserAsync(SignUpRequest signUp);
        Task<ApplicationUser?> LoginUserAsync(SignInRequest signIn);
        Task<string> CreateTokenAsync(ApplicationUser user);
    }
}
