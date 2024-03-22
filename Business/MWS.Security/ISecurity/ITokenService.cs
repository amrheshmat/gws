using Microsoft.AspNetCore.Mvc;
using MWS.Business.Shared.Data.Models;

namespace MWS.Security.ISecurity
{
    public interface ITokenService
    {
        Task<ActionResult<UserDTO>> CreateToken(string name, string password);
    }
}
