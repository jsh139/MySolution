using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using WebAppExercise.Models;

namespace WebAppExercise.Security
{
    public class AuthorizationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly IOptions<List<ApiKey>> _keys;

        public AuthorizationFilter(IOptions<List<ApiKey>> keys)
        {
            _keys = keys;
        }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var allowAnonymous = filterContext.ActionDescriptor.EndpointMetadata.Any(em =>
                em.GetType() == typeof(AllowAnonymousAttribute));

            if (allowAnonymous)
                return;

            var apiKey = filterContext.HttpContext.Request.Headers[SecurityConstants.ApiKeyHeaderName];
            var key = _keys.Value.FirstOrDefault(k => k.KeyValue == apiKey);

            if (key == null)
            {
                filterContext.Result = new UnauthorizedResult();
                return;
            }

            if (key.KeyType == SecurityConstants.KeyTypeFullAccess)
            {
                var claims = new List<Claim>
                {
                    new Claim(SecurityConstants.ClaimTypeIncludePII, string.Empty)
                };

                var appIdentity = new ClaimsIdentity(claims);
                filterContext.HttpContext.User.AddIdentity(appIdentity);
            }
        }
    }
}
