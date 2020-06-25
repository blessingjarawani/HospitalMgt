using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Interfaces;

namespace BLL.Models
{
    public class User 
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public UserType UserType { get; private set; }


        public User(string userName , string password, UserType userType)
        {
            this.UserType = userType;
            this.Username = userName;
            this.Password = password;
        }
    }
}
