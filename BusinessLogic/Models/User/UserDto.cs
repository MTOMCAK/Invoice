using DataAccess.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessLogic
{
    [Serializable]
    public class UserDto : IUser
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
    }
}