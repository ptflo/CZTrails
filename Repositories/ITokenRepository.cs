using Microsoft.AspNetCore.Identity;

namespace CZTrails.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
