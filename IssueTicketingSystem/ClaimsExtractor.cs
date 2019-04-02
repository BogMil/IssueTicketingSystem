using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace IssueTicketingSystem
{
    public static class ClaimsExtractor
    {

        public static int GetIdNaloga(this IPrincipal user)
        {
            if (user != null)
                return (int) user.GetClaimValueAsInt(CustomClaimTypes.IdAccount);
            throw new Exception("User is not logged in.");
        }

        public static int GetIdCompany(this IPrincipal user)
        {
            var idNalogaString = user.GetClaimValue(CustomClaimTypes.IdCompany);
            int.TryParse(idNalogaString, out var idNaloga);
            return idNaloga;
        }

        private static string GetClaimValue(this IPrincipal user, string type)
        {
            var claimsIdentity = user.Identity as ClaimsIdentity;

            var value = claimsIdentity?.Claims
                .Where(x => x.Type == type)
                .Select(x => x.Value).SingleOrDefault();

            return value;
        }

        private static int? GetClaimValueAsInt(this IPrincipal user, string type)
        {
            var valueAsString = user.GetClaimValue(type);
            int.TryParse(valueAsString, out var intValue);
            return intValue;
        }

        public static bool HasAnyOfRoles(this IPrincipal user, params string[] roles)
        {
            return roles.Any(user.IsInRole);
        }

    }
}