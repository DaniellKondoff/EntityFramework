using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.HospitalDB.Models
{
     partial class Patient
    {
        private bool EmailIsValid(string email)
        {
            string regularExpressionString = @"([a-zA-Z0-9][a-zA-Z_\-.]*[a-zA-Z0-9])@([a-zA-Z-]+\.[a-zA-Z-]+(\.[a-zA-Z-]+)*)\b";
            Regex regex = new Regex(regularExpressionString);

            if (!regex.IsMatch(email))
            {
                return false;
            }

            return true;
        }
    }
}
