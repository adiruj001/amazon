using BaseRestApi.Lib.Interface;
using BaseRestApi.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BaseRestApi.Lib
{
    public class JwtService : IJwtService
    {
        private AppSettings AppSettings { get; }

        public JwtService(IOptions<AppSettings> appSettings)
        {
            AppSettings = appSettings.Value;
        }
        public string DecodeJwtAndGetClaimValue(HttpRequest httpRequest, string key = "unique_name")
        {
            var authorization = httpRequest.Headers["Authorization"].ToString().Replace("Bearer", "").Replace(" ", "");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(authorization) as JwtSecurityToken;
            string value = jsonToken.Payload[key].ToString();
            return value;
        }

        public string GenerateJwtTokenString(string uniqueName, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //TODO: Use the JWT key from appsetting
            var jwtKey = Encoding.ASCII.GetBytes(AppSettings.Jwt.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, uniqueName),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.Now.AddDays(AppSettings.Jwt.ExpireInSec),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return (tokenString);
        }
    }
}
