using BLL.Infrastructure.Shared.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.ViewModel
{
    public class EmployeeFlitersViewModel
    {
        public  string   IdNumber { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }
    }
}
