using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databaze_maui.Interfaces
{
     interface IBirthDateValidator
    {
        bool IsValid(DateTime birthDate);
    }

    public class BirthDateValidator : IBirthDateValidator
    {
        public bool IsValid(DateTime birthDate)
        {
         
            return birthDate < DateTime.Now;
        }
    }
}
