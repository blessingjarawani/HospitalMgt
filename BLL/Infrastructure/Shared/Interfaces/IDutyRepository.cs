using BLL.Infrastructure.Shared.Responses;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Shared.Interfaces
{
    public interface IDutyRepository
    {
      
        ObjectResponse<bool> AddDuty(string name, TimeSpan startTime, TimeSpan endTime);
    }
}
