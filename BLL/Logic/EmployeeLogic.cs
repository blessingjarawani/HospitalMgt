using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Interfaces;
using BLL.Infrastructure.Shared.Responses;
using BLL.Models;
using BLL.Models.Abstracts;
using BLL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeLogic(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ObjectResponse<bool> AddEmployee(string name, string surname, string idNumber, string userName, string password, JobTitle jobTitle, int? gmcNumber = null, Speciality? speciality = null)
        {
            try
            {
                var employee = EmployeeFactory.CreateEmployee(name, surname, idNumber, userName, password, jobTitle, gmcNumber, speciality);
                if (!employee.Success && employee.Result == null)
                {
                    return new ObjectResponse<bool> { Success = false, Error = employee.Error };
                }
                var result = _employeeRepository.CreateEmployee(employee.Result);

                return result.Success ? new ObjectResponse<bool> { Success = true, Result = result.Result }
                  : new ObjectResponse<bool> { Success = false, Error = result.Error };
            }
            catch (Exception ex)
            {
                return new ObjectResponse<bool> { Success = false, Error = ex.GetBaseException().Message };
            }

        }

        public ObjectResponse<List<Employee>> GetEmployees(EmployeeFlitersViewModel employeeFlitersViewModel)
        {
            try
            {
                var result = _employeeRepository.GetEmployee(employeeFlitersViewModel);
                if (!result.Success)
                {
                    return new ObjectResponse<List<Employee>> { Success = false, Error = result.Error };
                }
                return new ObjectResponse<List<Employee>> { Success = true, Result = result.Result };
            }
            catch (Exception ex)
            {
                return new ObjectResponse<List<Employee>> { Success = false, Error = ex.GetBaseException().Message };
            }
        }

    }


}
