using innfact_B.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace innfact_B.Helper
{
    public class JwtHelper
    {
        private readonly IConfiguration Configuration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string GenerateToken(string userName, int expireDay = 1)
        {
            var issuer = Configuration.GetValue<string>("JwtSettings:Issuer");
            var signKey = Configuration.GetValue<string>("JwtSettings:SignKey");

            // 建立一組對稱式加密的金鑰，主要用於 JWT 簽章之用
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // 建立 SecurityTokenDescriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Expires = DateTime.Now.AddDays(expireDay),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializeToken = tokenHandler.WriteToken(securityToken);

            return serializeToken;
        }
        public Line DecodingJWT(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var result = new Line();
            var jwtPayload = handler.ReadJwtToken(token).Payload;
            result.UserID = jwtPayload.Where(x => x.Key == "sub").FirstOrDefault().Value.ToString();
            result.Email = jwtPayload.Where(x => x.Key == "email").FirstOrDefault().Value.ToString();
            result.Name = jwtPayload.Where(x => x.Key == "name").FirstOrDefault().Value.ToString();
            return result;
            
        }
    }
}
