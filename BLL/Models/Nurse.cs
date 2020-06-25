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
    public class Nurse : Employee, IDuties
    {
        public List<DutyRoster> Duties { get;  set; } = new List<DutyRoster>();
        public Nurse(string name, string surname, string idnumber, JobTitle jobTitle, string userName, string password) :
            base(name, surname, idnumber, jobTitle, userName, password, UserType.Nurse)
        {
        }
        public bool ValidateDuties(DutyRoster duty)
        {
            if (duty?.Duty == null)
            {
                return false;
            }
            var tommorow = duty.Date.AddDays(1);
            var yesterday = duty.Date.AddDays(-1);
            var isduty = Duties.Where(x => x.Date.ToShortDateString() == tommorow.ToShortDateString()
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
            return false;
        }

        public bool AssignDuties(DutyRoster duty)
        {
            if (ValidateDuties(duty))
            {
                var isduty = Duties?.FirstOrDefault(x => x.Date == x.Date && x.Duty.Name == duty.Duty.Name);
                if (isduty != null)
                {
                    Duties.Remove(isduty);
                }
                Duties.Add(duty);
                return true;
            }
            return false;
        }
    }
}
