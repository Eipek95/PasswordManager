using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Services.Contracts
{
    public interface IAuthService
    {
        Task LogOut();
        bool IsUserSignedIn(ClaimsPrincipal user);
        Task<SignInResult> SignInAsync(string email, string password, bool rememberMe);
        Task<int> GetAccessFailedCountAsync(string email);

        Task<string> GetIdentityUserIdrwithIdentityUserNameAsync(string userName);

        Task<IdentityResult> RegisterUserAsync(string userName, string email, string password);
    }
}
