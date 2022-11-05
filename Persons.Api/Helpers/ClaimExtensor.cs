using System.Security.Claims;
using System.Security.Principal;

public static class IdentityExtensions
{
    public static string GetUserId(this IIdentity identity)
    {
        ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
        Claim claim = claimsIdentity?.FindFirst("UserId");

        if (claim == null)
            return string.Empty;

        return (claim.Value);
    }

    public static string GetName(this IIdentity identity)
    {
        ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
        Claim claim = claimsIdentity?.FindFirst(ClaimTypes.Name);

        return claim?.Value ?? string.Empty;
    }
}