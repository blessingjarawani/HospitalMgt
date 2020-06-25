using BLL.Infrastructure.Shared.Dictionaries;
using BLL.Infrastructure.Shared.Interfaces;
using BLL.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Models
{
    public class Doctor : Employee, IDuties
    {
        public Speciality Speciality { get;  set; }
        public int GmcNumber { get; private set; }
        public List<DutyRoster> Duties { get;  set; } = new List<DutyRoster>();

        
       
        //To do inject lst of duties and check
        public Doctor(string name, string surname, string idNumber, string userName, string password, int gmcNumber, JobTitle jobTitle, Speciality speciality)
            : base(name, surname, idNumber, jobTitle, userName, password, UserType.Doctor)
        {
            Speciality = speciality;
            GmcNumber = gmcNumber;
        }

        public bool ValidateDuties(DutyRoster duty)
        {
            if (duty?.Duty == null)
            {
                return false;
            }
            var tommorow = duty.Date.AddDays(1);
            var yesterday = duty.Date.AddDays(-1);
            var isduty = Duties.FirstOrDefault(x => x.Date.ToShortDateString() == tommorow.ToShortDateString()
            || x.Date.ToShortDateString() == yesterday.ToShortDateString());

            if (isduty != null)
            {
                return false;
            }

            var count = Duties?.Where(x => x.Date.Month == duty.Date.Month)?.Count();

            if (count != null && count >= 20)
            {
                return false;
            }
            return true;
        }

   
        public bool AssignDuties(DutyRoster duty)
        {
            
            if (ValidateDuties(duty))
            {
                var isduty = Duties?.FirstOrDefault(x => x.Date == x.Date && x.Duty.Name == duty.Duty.Name);
                if (isduty != null)
                {
                    Duties.Add(isduty);
                }
                Duties.Add(duty);
                return true ;
            }
            return false;
        }
    }
}
