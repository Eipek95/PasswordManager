using Microsoft.AspNetCore.Identity;
using Repositories.Models;
using Services.Contracts;

namespace Services
{
    public class IdentityUserService : IIdentityUserService
    {
        private UserManager<AppUser> _userManager;

        public IdentityUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetIdentityUserIdrwithIdentityUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user!.Id;
        }
    }
}
