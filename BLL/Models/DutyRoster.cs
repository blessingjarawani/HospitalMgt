using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public class DutyRoster
    {
        public string IdNumber{ get; set; }
        public DateTime Date { get;  set; }
        public Duty Duty { get; set; }
    }
}
