using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Model;

namespace TodoAPI.Utility
{
    public class TokensGeneratorService : ITokensGeneratorService
    {
        private readonly IConfiguration _configuration;
        public TokensGeneratorService(IConfiguration configuration)
        {
             _configuration = configuration;
        }
        public async Task<string> GenerateTokenAsync(AppUser user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
           
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            int.TryParse(_configuration["JwtSettings:TokenValidityInMinutes"], out var tokenValidityInMinutes);
            // Specifying JWTSecurityToken Parameters
            var token = new JwtSecurityToken
            (audience: _configuration["JwtSettings:Audience"],
             issuer: _configuration["JwtSettings:Issuer"],
             claims: authClaims,
             expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
             signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
