using BLL.Infrastructure.Shared.Interfaces;
using BLL.Infrastructure.Shared.Responses;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic.Respository
{
    public class DutyRepository : IDutyRepository
    {
        private static List<Duty> Duties = new List<Duty>();

        public ObjectResponse<bool> AddDuty(string name, TimeSpan startTime, TimeSpan endTime)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return new ObjectResponse<bool> { Success = false, Error = "Invalid Duty Name" };
                }
                var duty = Duties?.FirstOrDefault(x => x.Name == name);
                if (duty != null)
                {
                    Duties.Remove(duty);
                }
                Duties.Add(new Duty
                {
                    Name = name,
                    StartTime = startTime,
                    EndTime = endTime,

                });
                return new ObjectResponse<bool> { Success = true, Result = true };
            }
            catch (Exception ex)
            {
                return new ObjectResponse<bool> { Success = false, Error = ex.GetBaseException().Message };
            }
        }


       



    }
}
