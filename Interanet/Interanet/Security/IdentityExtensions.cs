using Interanet.Model.View;
using System.Security.Claims;
using System.Security.Principal;

namespace Interanet.API.Security
{
    public static class IdentityExtensions
    {

        public static string? GetUserId(this IIdentity identity)
        {
            var ident = identity as ClaimsIdentity;
            if (ident != null)
            {
                var claim = ident.FindFirst("uid");
                if (claim != null)
                    return claim.Value;
            }

            return null;
        }

        public static string? GetUserGroupId(this IIdentity identity)
        {
            var ident = identity as ClaimsIdentity;
            if (ident != null)
            {
                var claim = ident.FindFirst("gid");
                if (claim != null)
                    return claim.Value;
            }

            return null;
        }


        
    }
}