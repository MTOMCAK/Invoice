using BusinessLogic.Interfaces;
using BusinessLogic.UserApi;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BusinessLogic.API_Auth
{
    public class UserManager : UserManager<IdentityUser, int>
    {
        public UserManager(IUserStore userStore) : base(userStore) { }

        public async Task<IdentityUser> FindUserByEmailAsync(string email, string password)
        {
            var user = await UserBL.FindByEmailAsync(email, password);
            return user ?? null;
        }

        public async Task<bool> CreateUserAsync(IdentityUser user)
        {
            return await UserBL.CreateUserAsync(user);
        }
    }
}