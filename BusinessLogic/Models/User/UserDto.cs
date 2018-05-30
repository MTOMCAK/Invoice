using BusinessLogic.UserApi;
using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessLogic
{
    [Serializable]
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }


        public UserDto()
        {
        }

        public UserDto(User user)
        {
            FromEntity(user);
        }

        public void FromEntity(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            FullName = FirstName + " " + LastName;
            Email = user.Email;
        }

        public User ToEntity(IdentityUser user)
        {
            var entity = new User();
            entity.Id = Id;
            if (user.UserName.Contains(' '))
            {
                entity.FirstName = user.UserName.Split(' ')[0];
                entity.LastName = user.UserName.Split(' ')[1];
            }
            else
            {
                entity.FirstName = user.UserName;
                entity.LastName = user.UserName;
            }
            entity.Email = user.Email;
            entity.PasswordHash = user.PasswordHash;
            return entity;
        }
    }
}