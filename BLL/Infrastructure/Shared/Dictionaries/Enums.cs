using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure.Shared.Dictionaries
{
    public enum JobTitle
    {
        Doctor = 1,
        Nurse = 2,
        Administrator = 3
    }

    public enum Speciality
    {
        Cardiologist = 1,
        Urologist = 2,
        Neurologist = 3,
        Laryngologist = 4

    }

    public enum UserType
    { 
        Administrator =1,
        Nurse =2,
        Doctor =3,
    }
}
