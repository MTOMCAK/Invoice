using BusinessLogic.UserApi;
using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace BusinessLogic.API_Auth
{
    public class AuthRepository
    {
        private UserManager _userManager;

        public AuthRepository()
        {
            _userManager = new UserManager(new UserStore());
        }

        public async Task<bool> RegisterUser(IdentityUser user)
        {
            var result = await _userManager.CreateUserAsync(user);
            return result;
        }

        public async Task<IdentityUser> FindUserByEmail(string email, string password)
        {
            return await _userManager.FindUserByEmailAsync(email, password);
        }
    }
}