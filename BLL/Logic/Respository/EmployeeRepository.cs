using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Interfaces;
using BLL.Infrastructure.Shared.Responses;
using BLL.Models;
using BLL.Models.Abstracts;
using BLL.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic.Respository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static List<Employee> Employees { get; set; } = new List<Employee>();

        public ObjectResponse<bool> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    return new ObjectResponse<bool> { Success = false, Error = "Can not add Empty Employee" };
                }
                var result = Employees.FirstOrDefault(x => x.IdNumber == x.IdNumber);
                if (result != null)
                {
                    Employees.Remove(result);
                }

                Employees.Add(employee);
                return new ObjectResponse<bool> { Success = true, Result = true };
            }
            catch (Exception ex)
            {
                return new ObjectResponse<bool> { Success = false, Error = ex.GetBaseException().Message };
            }

        }

        public ObjectResponse<List<Employee>> GetEmployee(EmployeeFlitersViewModel employeeFlitersViewModel)
        {
            try
            {
                var result = Employees;
                if (!string.IsNullOrWhiteSpace(employeeFlitersViewModel.IdNumber))
                {
                    result = result.Where(x => x.IdNumber == employeeFlitersViewModel.IdNumber).ToList();
                }

                return new ObjectResponse<List<Employee>> { Success = true, Result = result };
            }
            catch (Exception ex)
            {
                return new ObjectResponse<List<Employee>> { Success = false, Error = ex.GetBaseException().Message };
            }
        }

        public ObjectResponse<bool> AddemployeeDuties(IDuties duties, List<DutyRoster> dutyRosters)
        {
            try
            {
                foreach (var duty in dutyRosters)
                {
                    duties.AssignDuties(duty);
                }
                if (duties.Duties.Count > 0)
                {
                    UpdateDuties(duties.Duties);
                }
                return new ObjectResponse<bool> { Success = true, Result = true };
            }
            catch (Exception ex)
            {
                return new ObjectResponse<bool> { Success = false, Error = ex.GetBaseException().Message };
            }
        }

        private bool UpdateDuties(List<DutyRoster> duties)
        {
            var emp = Employees?.Where(x => x.IdNumber == duties?.FirstOrDefault().IdNumber)?.FirstOrDefault();

            if (emp != null)
            {
                if (emp.JobTitle == JobTitle.Doctor)
                {
                    var doctor = (Doctor)emp;
                    Employees.Remove(emp);
                    Employees.Add(doctor);
                }
                else if (emp.JobTitle == JobTitle.Nurse)
                {
                    var nurse = (Nurse)emp;
                    nurse.Duties = duties;
                    Employees.Remove(emp);
                    Employees.Add(nurse);
                }
                return true;
            }
            return false;
        }

    }
}
