using BusinessLogic.UserApi;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IUserStore : IUserPasswordStore<IdentityUser, int>
    {
        Task<IdentityUser> FindUserByNameAsync(string userName);

        Task CreateUserLoginHistory(IdentityUser userDeviceLogin);
    }
}
