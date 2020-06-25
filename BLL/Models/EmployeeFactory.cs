using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Interfaces;
using BLL.Infrastructure.Shared.Responses;
using BLL.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class EmployeeFactory
    {
        public static ObjectResponse<Employee> CreateEmployee(string name, string surname, string idNumber, string userName, string password, JobTitle jobTitle, int? gmcNumber = null, Speciality? speciality = null)
        {
            if (!ValidateEmployee(name, surname, idNumber, userName, password, jobTitle, gmcNumber, speciality))
            {
                return new ObjectResponse<Employee> { Success = false, Error = "Invalid Input" };
            }
            switch (jobTitle)
            {
                case JobTitle.Administrator:
                    {
                        return new ObjectResponse<Employee> { Success = true, Result = new Administrator(name, surname, idNumber, userName, password, jobTitle) };
                    }
                case JobTitle.Doctor:
                    {
                        return new ObjectResponse<Employee> { Success = true, Result = new Doctor(name, surname, idNumber, userName, password, gmcNumber.Value, jobTitle, speciality.Value) };
                    }
                case JobTitle.Nurse:
                    {
                        return new ObjectResponse<Employee> { Success = true, Result = new Nurse(name, surname, idNumber, jobTitle, userName, password) };
                    }
                default:
                    return new ObjectResponse<Employee> { Success = false, Error = "Unkwown Employee" };
            }
        }


        private static bool ValidateEmployee(string name, string surname, string idNumber, string userName, string password, JobTitle jobTitle, int? gmcNumber = null, Speciality? speciality = null)
        {
            if (string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(idNumber) || string.IsNullOrWhiteSpace(userName)
                || string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            if (jobTitle == JobTitle.Doctor && (!speciality.HasValue || !gmcNumber.HasValue || gmcNumber.Value.ToString().Length != 7))
            {
                return false;
            }
            return true;
        }

      
    }
}
