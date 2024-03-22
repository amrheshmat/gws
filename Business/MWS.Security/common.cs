using Microsoft.AspNetCore.Http;
using MWS.Business.Shared.Data.Models;

namespace MWS.Security
{
    public class Common
    {
        public static UserDTO? Getuser(HttpContext context)
        {
            UserDTO? user = null;
            //Get user regiterd by jwt token ...
            user = (UserDTO?)context.Items["User"];
            return user;

        }
    }
}
