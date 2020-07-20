using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.src.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;


        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        public IActionResult Authentication(UserLogin userLogin)
        {
            if (IsValidUser(userLogin))
            {
                var token = GenerateToken();


                return Ok(new { token });
            }

            return NotFound();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        private bool IsValidUser(UserLogin userLogin)
        {
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GenerateToken()
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);


            //Claims(Lo que queremos validar, caracteristicas del usuario)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Magdiel Efrain"),
                new Claim(ClaimTypes.Email, "magefra9@hotmail.com"),
                new Claim(ClaimTypes.Role, "Administrador")
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(2)

            );

            //Signature
            var token = new JwtSecurityToken(header, payload);


            //Serializa un securityToken(string)
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
