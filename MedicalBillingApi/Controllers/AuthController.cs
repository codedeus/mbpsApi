using MedicalBillingApi.Auth;
using MedicalBillingApi.Entities;
using MedicalBillingApi.Helpers;
using MedicalBillingApi.Interfaces;
using MedicalBillingApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalBillingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDataContext _dbContext;
        private readonly IJwtFactory _jwtFactory;
        private readonly ITokenFactory _tokenFactory;
        private readonly AuthSettings _authSettings;
        private readonly IJwtTokenValidator _jwtTokenValidator;
        public AuthController(AppDataContext dbContext, UserManager<AppUser> userManager, IJwtFactory jwtFactory, 
            ITokenFactory tokenFactory, IOptions<AuthSettings> authSettings,
             IJwtTokenValidator jwtTokenValidator)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _tokenFactory = tokenFactory;
            _authSettings = authSettings.Value;
            _jwtTokenValidator = jwtTokenValidator;
            _dbContext = dbContext;
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] LoginModel credentials)
        {

            var user = await _userManager.FindByEmailAsync(credentials.Email);
            if (user != null)
            {
                // validate password
                if (await _userManager.CheckPasswordAsync(user, credentials.Password))
                {
                    // generate refresh token
                    var refreshToken = _tokenFactory.GenerateToken();
                    // generate access token
                    return Ok(new LoginResponse(await _jwtFactory.GenerateEncodedToken(user.Id, user.Email), refreshToken, user.Role, user.DepartmentId));
                    //return true;
                }
            }
            return BadRequest("Invalid username or password");
        }
    }
}