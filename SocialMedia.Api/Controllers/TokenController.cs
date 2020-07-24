using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.src.Entities;
using SocialMedia.Core.src.Interfaces.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        private readonly ISecurityService _securityService;





        public TokenController(IConfiguration configuration,
                               ISecurityService securityService)
        {
            _configuration = configuration;
            _securityService = securityService;
        }


        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin userLogin)
        {

            var validation = await IsValidUser(userLogin);

            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);


                return Ok(new { token });
            }

            return NotFound();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        private async Task<(bool, Security)> IsValidUser(UserLogin userLogin)
        {
            var user =await _securityService.GetLoggingByCredentials(userLogin);

            return (user != null, user);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GenerateToken(Security security)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);


            //Claims(Lo que queremos validar, caracteristicas del usuario)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, security.UserName),
                new Claim("User", security.User),
                new Claim(ClaimTypes.Role, security.Role.ToString())
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)

            );

            //Signature
            var token = new JwtSecurityToken(header, payload);


            //Serializa un securityToken(string)
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
