using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Responses;
using BLL.Models;
using BLL.Models.Abstracts;
using BLL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Shared.Interfaces
{
    public interface IEmployeeRepository
    {
        ObjectResponse<bool> CreateEmployee(Employee employee);
        ObjectResponse<List<Employee>> GetEmployee(EmployeeFlitersViewModel employeeFlitersViewModel);
        ObjectResponse<bool> AddemployeeDuties(IDuties duties, List<DutyRoster> dutyRosters);
    }
}
