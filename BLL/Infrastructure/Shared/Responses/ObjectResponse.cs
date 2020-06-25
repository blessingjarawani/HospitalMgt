using BLL.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Shared.Responses
{
    public class ObjectResponse<T> : BaseResult
    {
        public T Result { get; set; }
    }
}
