using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MWS.Data.Entities;

namespace MWS.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AppAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// Method to check if there is an authenticated user attached to the current request (context.HttpContext.Items["User"]). An authenticated user is attached by the custom jwt middleware if the request contains a valid JWT access token.
        /// </summary>
        /// <param name="context"></param>
        /// <retuns>On successful authorization no action is taken and the request is passed through to the controller action method, if authorization fails a 401 Unauthorized response is returned.</retuns>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            if (context.HttpContext.Items["User"] == null)
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}
