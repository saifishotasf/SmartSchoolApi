using Contracts.DomainContracts;
using DomainModels;
using DomainModels.Request.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utility;
using Utility.LoggerService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IUser _user;

        public AccountsController(ILoggerManager logger, IUser user)
        {
            _logger = logger;
            _user = user;
        }


        [HttpPost, Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] TokenRequest request)
        {
            //request.Password = SHA256Cryptography.GetHashString(request.Password);

            var user = await _user.GetUser(request.UserName, request.Password);

            if (user != null)
            {
                Utility.LoggedInUserDetails.Id = user.Id;
                Utility.LoggedInUserDetails.UserName = user.UserName;
            }

            var tokenResponse = GenerateToken(user);

            if (string.IsNullOrEmpty(tokenResponse.Error))
            {
                tokenResponse.IsSuccess = true;
                tokenResponse.LoginId = user.Email;
                tokenResponse.UserName = user.FirstName + " " + user.LastName;
                tokenResponse.Token_type = ApplicationSettings.TokenType;
            }

            return Ok(tokenResponse);
        }

        private TokenResponse GenerateToken(UserDomainModel userObj)
        {
            TokenResponse tokenResponse = new TokenResponse();

            var token = GetAccessToken(userObj);

            tokenResponse.Access_token = token;
            tokenResponse.AccessRights = userObj.RoleId.ToString();
            tokenResponse.Expires = DateTime.Now;
            tokenResponse.TimeOutMins = ApplicationSettings.ScreenTimeoutMins;

            return tokenResponse;
        }

        /// <summary>
        /// This function generates access token with claim it returns jwt token
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        private string GetAccessToken(UserDomainModel userObj)
        {
            var key = Encoding.UTF8.GetBytes(ApplicationSettings.Secret);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, ApplicationSettings.Audiance),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ApplicationSettings.ClaimTypeId,userObj.Id.ToString()),
                new Claim(ApplicationSettings.ClaimTypeFullName, userObj.FirstName + "" + userObj.LastName),
                new Claim(ClaimTypes.Role, userObj.RoleId.ToString()),
                new Claim(ApplicationSettings.ClaimContact, userObj.Contact),
                new Claim(ApplicationSettings.ClaimTypeEmail, userObj.Email)
            };

            var token = new JwtSecurityToken(
                    ApplicationSettings.Issuer,
                    ApplicationSettings.Issuer,
                    claims,
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
