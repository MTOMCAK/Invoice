using BusinessLogic.UserApi;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogic
{
    public class UserBL
    {
        #region PUBLIC_METHODS
        public static async Task<bool> CreateUserAsync(IdentityUser user)
        {
            try
            {
                var userEntity = new UserDto().ToEntity(user);
                // set values
                userEntity.DbStatus = (int)Enums.eDbStatus.Active;
                userEntity.PasswordHash = generateHash(user.Password);
                userEntity.CreatedBy = 1;
                userEntity.CreatedDate = DateTime.Now;
                return await UserDA.CreateUserAsync(userEntity);
            }
            catch
            {
                return false;
            }
        }

        public static async Task<IdentityUser> FindByEmailAsync(string email, string password)
        {
            var result = await UserDA.FindByEmailAsync(email, generateHash(password));
            return result != null ? new IdentityUser(result) : null;
            // TODO dorobit
        }
        #endregion PUBLIC_METHODS

        #region PRIVATE_METHODS

        private static string generateHash(string password)
        {
            HashAlgorithm algorithm = MD5.Create();
            var passwordHash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(passwordHash);
        }
        #endregion PRIVATE_METHODS
    }
}