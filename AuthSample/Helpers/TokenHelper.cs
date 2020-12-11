using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using AuthSample.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace AuthSample.Helpers
{
    public class TokenHelper
    {
        public const string Issuer = "http://skpatel.net";
        public const string Audience = "http://skpatel.net";

        /// <summary>
        /// Base 64 encoded string 
        /// </summary>
        public const string Secret = "OFRC1j9aaR2BvADxNWlG2pmuD392UfQBZZLM1fuzDEzDlEpSsn+btrpJKd3FfY855OMA9oK4Mc8y48eYUrVUSw==";

        public static string GenerateSecureSecret()
        {
            var hmac = new HMACSHA256();
            return Convert.ToBase64String(hmac.Key);
        }

        public static string GenerateTokern(UserModel userModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(Secret);
            var claimsIdentity = new ClaimsIdentity(new[]{
                new Claim(ClaimTypes.NameIdentifier,userModel.UserId.ToString()),
                new Claim("IsBlocked",userModel.IsBlocked.ToString())
            });

            var signingCredential = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject=claimsIdentity,
                Issuer=Issuer,
                Audience=Audience,
                Expires=DateTime.Now.AddMinutes(15),
                SigningCredentials=signingCredential
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
