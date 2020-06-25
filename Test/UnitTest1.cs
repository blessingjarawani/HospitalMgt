using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Interfaces;
using BLL.Logic;
using BLL.Logic.Respository;
using BLL.Models;
using BLL.Models.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        IEmployeeRepository employeeRepository;
        IEmployeeLogic employeeLogic;
        EmployeeFlitersViewModel filters = new EmployeeFlitersViewModel();
        IDuties _iduties;
        IDutyRepository dutyRepository;
        public UnitTest1()
        {
            employeeRepository = new EmployeeRepository();
            employeeLogic = new EmployeeLogic(employeeRepository);
            dutyRepository = new DutyRepository();
           
        }
        [TestMethod]

        public void TestMethod1()
        {
           
            employeeLogic.AddEmployee("Test", "Test", "744", "Jabu", "xxxxx", JobTitle.Nurse);
            employeeLogic.AddEmployee("Test", "Test", "788", "Jabu", "xxxxx", JobTitle.Administrator);
            employeeLogic.AddEmployee("Test", "Test", "7555", "Jabu", "xxxxx", JobTitle.Doctor, 1234567, Speciality.Cardiologist);
            filters.IdNumber = "788";
            employeeRepository.GetEmployee(filters);
            filters.IdNumber = "7555";
            
            var emp =  employeeRepository.GetEmployee(filters).Result?.FirstOrDefault();

            Doctor z = (Doctor)emp;
            var duties =new DutyRoster
            {
                IdNumber = z.IdNumber,
                Date = DateTime.Now,
                Duty = new Duty{StartTime = DateTime.Now.TimeOfDay , EndTime = DateTime.Now.TimeOfDay , Name ="Test"}
            };

            List<DutyRoster> list = new List<DutyRoster>();
            list.Add(duties);
            employeeRepository.AddemployeeDuties(z, list);
            
            
            

        }
    }
}
