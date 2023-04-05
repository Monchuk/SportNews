using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sport.API.Extentions;
using Sport.Business.Servises.Interfaces;
using Sport.DataAccess.Models;
using Sport.DataTransfer.Dtos;
using Sport.DataTransfer.Requests;
using SportNewsBackend;
using System.Security.Claims;
using System.Security.Principal;

namespace Sport.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IIdentityManager _identityManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public AuthController(IIdentityManager identityManager, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _identityManager = identityManager;
            _userManager= userManager;
            _mapper = mapper;
        }

        //[HttpPost("sign-up")]
        //public async Task<IActionResult> SignUp([FromBody]SignUpRequest request)
        //{
        //    var userResult = await _identityManager.RegisterUserAsync(request);

        //    return Created("",null);

        //}
        [HttpPost("sign-up")]
        public async Task<ActionResult<TokenDto>> SignUp([FromBody] SignUpRequest request)
        {
            var userResult = await _identityManager.RegisterUserAsync(request);
            if (userResult is null)
            {
                return BadRequest();
            }
            return new TokenDto { Token = await _identityManager.CreateTokenAsync(userResult) }; 

        }


        [HttpPost("sign-in")]
        public async Task<ActionResult<TokenDto>> SignIn([FromBody] SignInRequest request)
        {
            var user = await _identityManager.LoginUserAsync(request);
            if (user is null)
            {
                return Unauthorized();
            }
            return new TokenDto { Token =await _identityManager.CreateTokenAsync(user)  };

        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<UserInfoDto>> UserInfo()
        {
            //var userId = User.FindFirst("Id")?.Value;
            //var user = await _userManager.GetUserById(userId);
            //return _mapper.Map<UserInfoDto>(user);
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var user = await _userManager.FindByNameAsync(userName);

            return _mapper.Map<UserInfoDto>(user);
        }
    }
}
