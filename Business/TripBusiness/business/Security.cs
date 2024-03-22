using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MWS.Business.Shared.Data.Models;
using MWS.Business.Shared.IBusiness;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TripBusiness.Ibusiness;

namespace TripBusiness.business
{
    public class Security : ISecurity
    {
        private readonly IConfiguration _config;
        private readonly ITripCaching _cache;
        private readonly IRepository _reop;
        private readonly IUserRolePermission _role;


        public Security(IConfiguration config, ITripCaching cache, IRepositoryFactory repo, IUserRolePermission role)
        {
            _config = config;
            _cache = cache;
            _reop = repo.Create("AGGRDB");
            _role = role;
        }

        public async Task<object> CreateToken(string name, string password)
        {

            // get users from cache ...
            var chachedUsers = await _cache.getUsers();
            User user = chachedUsers.FirstOrDefault(u => u.userName!.ToLower() == name.ToLower());
            if (user == null) return "404";
            //verify password with hashing...
            //var isCorrectPassword = MPSSecurity.Verify(user.password!, password);
            //if (!isCorrectPassword)
            if (password != user.password)
            {
                return "404";
            }
            //get permission by user role
            List<Permission> permissions = await _role.getCurrentUserPermissions(user.roleId!.Value);
            //generate token ...
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config!.GetSection("TokenSettings:EncryptionKey").ToString() ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //token data ...
                Subject = new ClaimsIdentity(new[] { new Claim("Name", user!.userName!.ToString()),
                    new Claim("roleId", user!.roleId!.ToString() ?? "") }),

                // generate token that is valid for 7 days ...
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new UserDTO
            {
                userName = user.userName,
                mobile = user.mobile,
                token = tokenHandler.WriteToken(token),
                permissions = permissions,
            };

        }
    }
}
