using BLL.Models;
using BLL.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Shared.Interfaces
{
    public interface IDuties
    {
        List<DutyRoster> Duties { get; set; }
        bool AssignDuties(DutyRoster duty);

        bool ValidateDuties(DutyRoster duty);
    }
}
