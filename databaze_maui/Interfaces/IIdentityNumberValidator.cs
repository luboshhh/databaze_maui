using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databaze_maui.Interfaces
{
     interface IIdentityNumberValidator
    {
        bool IsValid(string identityNumber, DateTime birthDate);
    }

    public class IdentityNumberValidator : IIdentityNumberValidator
    {
        public bool IsValid(string identityNumber, DateTime birthDate)
        {
            
            if (birthDate < new DateTime(1954, 1, 1))
            {
               
                return identityNumber.Length == 9 &&
                       identityNumber[6] == '/' &&
                       identityNumber.Substring(0, 6).All(char.IsDigit) &&
                       identityNumber.Substring(7).All(char.IsDigit);
            }
            else
            {
              
                if (identityNumber.Length != 10 || identityNumber[6] != '/')
                {
                    return false;
                }

                
                if (long.TryParse(identityNumber.Replace("/", ""), out long idNumber))
                {
                    return idNumber % 11 == 0;
                }
            }

            return false;
        }
    }
}
