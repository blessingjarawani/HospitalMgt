using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Interfaces;
using BLL.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class Administrator : Employee
    {
        public Administrator(string name, string surname, string idNumber, string userName, string password, JobTitle jobTitle)
            : base(name, surname, idNumber, jobTitle, userName, password, UserType.Administrator)
        {

        }
     
    }
}
