using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Shared.Interfaces
{
    public interface IEmployeeLogic
    {
        ObjectResponse<bool> AddEmployee(string name, string surname, string idNumber, string userName, string password, JobTitle jobTitle, int? gmcNumber = null, Speciality? speciality = null);
    }
}
