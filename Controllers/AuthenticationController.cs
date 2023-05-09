using apifinal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RatingAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace apifinal.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticationServices _service;

        public AuthenticationController(IConfiguration config, IAuthenticationServices service)
        {
            _config = config; 
            _service = service;
        }

        [HttpPost("authenticate")] 
        public ActionResult<string> Autenticar(AuthenticationRequestBody authenticationRequestBody) 
        {
            
            var user = _service.ValidacionUsuario(authenticationRequestBody);

            if (user is null)
                return Unauthorized();

           
            var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"]));

            var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.Id.ToString())); 
            claimsForToken.Add(new Claim("given_name", user.Name)); 
            claimsForToken.Add(new Claim("family_name", user.SurName)); 
            claimsForToken.Add(new Claim("role", user.UserType.ToString())); 

            var jwtSecurityToken = new JwtSecurityToken(
              _config["Authentication:Issuer"],
              _config["Authentication:Audience"],
              claimsForToken,
              DateTime.UtcNow,
              DateTime.UtcNow.AddHours(1),
              credentials);

            var tokenToReturn = new JwtSecurityTokenHandler()
                .WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }
    }
}