using DataAccess.DataAccess;
using Microsoft.AspNet.Identity;

namespace BusinessLogic.UserApi
{
    public class IdentityUser : IUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAuthenticated { get; }

        public IdentityUser() { }

        public IdentityUser(User entity)
        {
            Id = entity.Id;
            UserName = entity.FirstName + " " + entity.LastName;
            Email = entity.Email;
            PasswordHash = entity.PasswordHash;
        }
    }
}