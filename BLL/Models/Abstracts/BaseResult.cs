using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models.Abstracts
{
    public class BaseResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }
    }
}
