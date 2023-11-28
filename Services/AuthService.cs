using Microsoft.AspNetCore.Identity;
using Repositories.Models;
using Services.Contracts;
using System.Security.Claims;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AuthService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public bool IsUserSignedIn(ClaimsPrincipal user)
        {
            return _signInManager.IsSignedIn(user);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<SignInResult> SignInAsync(string email, string password, bool rememberMe)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return SignInResult.Failed;
            }

            return await _signInManager.PasswordSignInAsync(user, password, rememberMe, true);
        }

        public async Task<int> GetAccessFailedCountAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return 0;
            }

            return await _userManager.GetAccessFailedCountAsync(user);
        }

        public async Task<string> GetIdentityUserIdrwithIdentityUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user!.Id;
        }

        public async Task<IdentityResult> RegisterUserAsync(string userName, string email, string password)
        {
            var result = await _userManager.CreateAsync(new()
            {
                UserName = userName,
                Email = email
            }, password);

            return result;
        }
    }
}
