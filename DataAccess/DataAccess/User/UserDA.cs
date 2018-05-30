using DataAccess.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDA
    {
        public static async Task<bool> CreateUserAsync(User user)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return true;
            }
        }

        public static async Task<User> FindByEmailAsync(string email, string passwordHash)
        {
            using (var context = new MatusTestingAssignmentEntities())
            {
                return await context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email) && u.PasswordHash.Equals(passwordHash));
            }
        }
    }
}