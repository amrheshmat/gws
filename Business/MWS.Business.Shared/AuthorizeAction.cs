using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using Newtonsoft.Json;

namespace MWS.Business.Shared
{
    public class AuthorizeAction : IAuthorizationFilter
    {
        private readonly string _actionName;
        private readonly string _permisssionArea;
        public AuthorizeAction(string actionName, string permisssionArea)
        {
            _actionName = actionName;
            _permisssionArea = permisssionArea;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var value = context.HttpContext.Session.GetString("currentUser");
            if (value != null)
            {
                UserDTO currentUser = JsonConvert.DeserializeObject<UserDTO>(value);
                List<Permission> permissions = currentUser.permissions;
                if (currentUser?.permissions.Where(e => e.permissionAction == _actionName && e.permissionArea == _permisssionArea).ToList().Count == 0)
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
