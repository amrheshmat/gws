using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Security.Caching;
using MWS.Security.ISecurity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MWS.Security.Security
{
    public class TokenService : ControllerBase, ITokenService
    {
        private readonly IConfiguration _config;
        private readonly ICacheProvider _memoryCache;


        public TokenService(IConfiguration config, ICacheProvider memoryCache)
        {
            _config = config;
            _memoryCache = memoryCache;
        }

        public async Task<ActionResult<UserDTO>> CreateToken(string name, string password)
        {
            // get users from cache ...
            var chachedUsers = await _memoryCache.MemoryCacheUsers();
            var user = chachedUsers.FirstOrDefault(u => u.USER_ID!.ToLower() == name.ToLower());
            if (user == null) return Unauthorized("Invalid UserName Or Password");
            //verify password with hashing...
            var isCorrectPassword = MPSSecurity.Verify(user.WEBPASSWORD!, password);
            if (!isCorrectPassword)
            {
                //Encrypt password ...
                var hashedPassword = MPSSecurity.Encrypt(password, DateTime.Parse("12/22/2013 14:35:31").ToString("o"));

                //verify password with encryption...
                if (user.WEBPASSWORD != hashedPassword) return Unauthorized("Invalid UserName Or Password");
            }
            //generate token ...
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config!.GetSection("TokenSettings:EncryptionKey").ToString() ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //token data ...
                Subject = new ClaimsIdentity(new[] { new Claim("Name", user!.USER_ID!.ToString()),
                    new Claim("Branch", user!.PARTNER_BRANCH!.ToString()),
                    new Claim("Partner", user!.PARTNER_CODE!.ToString() ?? "") }),

                // generate token that is valid for 7 days ...
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserDTO
            {
                userName = user.USER_ID,
                branch = user.PARTNER_BRANCH,
                partner = user.PARTNER_CODE,
                token = tokenHandler.WriteToken(token),
            };

        }
    }
}
