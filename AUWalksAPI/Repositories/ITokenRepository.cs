using Microsoft.AspNetCore.Identity;

namespace AUWalksAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}