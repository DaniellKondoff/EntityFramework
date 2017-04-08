using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Photography.Models.Validation
{
    class PhoneAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string phone = value.ToString();
            Regex regex = new Regex(@"\+\d{1,3}\/\d{8,10}");
            if (!regex.IsMatch(phone))
            {
                return false;
            }
            return true;
        }
    }
}
