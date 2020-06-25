using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Abstracts
{
    public abstract class Employee
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string IdNumber { get; private set; }
        public JobTitle JobTitle { get; private set; }
        public User Login { get; private set; }
        public Employee(string name, string surname, string idNumber, JobTitle jobTitle, string userName, string password, UserType userType)
                : this(new User(userName, password, userType))
        {
            this.Name = name;
            this.Surname = surname;
            this.IdNumber = idNumber;
            this.JobTitle = jobTitle;

        }
        private Employee(User user)
        {
            this.Login = user;
        }





    }
}
