using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MWS.Business.Shared.Data.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MWS.Shared
{
    public class JwtMiddleware
    {
        #region fields
        private readonly IConfiguration _config;
        private readonly RequestDelegate _next;
        #endregion
        #region constructor(s)
        public JwtMiddleware(IConfiguration config, RequestDelegate next)
        {
            _config = config;
            _next = next;
        }
        #endregion
        #region methods
        public UserDTO? ValidateJwtToken(string? token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_config.GetSection("TokenSettings:EncryptionKey").ToString() ?? "");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var user = new UserDTO();

                user.status = jwtToken.Claims.First(x => x.Type == "Status").Value;
                user.userName = jwtToken.Claims.First(x => x.Type == "Name").Value;
                user.roleId = jwtToken.Claims.First(x => x.Type == "roleId").Value;
                // return user id from JWT token if validation successful
                return user;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
        public async Task Invoke(HttpContext context)
        {
            string? token = context.Request.Headers["Authorization"];
            //check if basic authentication to call security project to generate token ...
            var val = context.Session.GetString("currentUser");
            UserDTO currentUser = new UserDTO();
            if (val != null)
            {
                currentUser = JsonConvert.DeserializeObject<UserDTO>(val);
                // when send bearer token in authorization ...
                token = currentUser.token;
            }
            UserDTO user = ValidateJwtToken(token)!;
            if (user != null)
            {
                user.permissions = currentUser.permissions;
                context.Items["User"] = user;
            }

            await _next(context);

        }
        #endregion
    }
}
