using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sport.Business.Exceptions;
using Sport.Business.Servises.Interfaces;
using Sport.DataAccess.Models;
using Sport.DataAccess.Constants;
using Sport.DataTransfer.Dtos;
using Sport.DataTransfer.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Sport.Business.Servises
{
    public class IdentityManager : IIdentityManager
    {
        private readonly UserManager<ApplicationUser>  _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
      
        public IdentityManager(UserManager<ApplicationUser> userManager, IMapper mapper, SignInManager<ApplicationUser> signManager, IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signManager;
            _config = config;
        }

        public async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(user);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        public async Task<ApplicationUser> RegisterUserAsync(SignUpRequest signUp)
        {
            var user = _mapper.Map<ApplicationUser>(signUp);
            user.UserName = signUp.Email;
            var result = await _userManager.CreateAsync(user, signUp.Password);
            if (!result.Succeeded) 
            {           
                throw new IdentityErrorException(ExceptionMessages.SomethingWentWrong, result.Errors);
            } 

            return user;
        }

        public async Task<ApplicationUser?> LoginUserAsync(SignInRequest signIn)
        {
            var user = await _userManager.FindByEmailAsync(signIn.Email);
            if (user is null) 
            {
                throw new IdentityErrorException(ExceptionMessages.ThisEmailNotExist);
               // return null;
            }

            var result =  await _signInManager.PasswordSignInAsync(user, signIn.Password,false,false);
            return result.Succeeded ? user : null;
        }

        //public async Task<UserInfoDto?> GetUserById(Guid userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId.ToString());

        //    return _mapper.Map<UserInfoDto>(user);
        //}

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _config.GetSection("jwtConfig");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
        {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(CustomClaimTypes.UserId, user.Id.ToString()) //TODO
               
        };
            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _config.GetSection("JwtConfig");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),          
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
