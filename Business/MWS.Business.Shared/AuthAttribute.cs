using Microsoft.AspNetCore.Mvc;

namespace MWS.Business.Shared
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute(string actionName, string permisssionArea) : base(typeof(AuthorizeAction))
        {
            Arguments = new object[] {
            actionName,
            permisssionArea
        };
        }
    }
}
