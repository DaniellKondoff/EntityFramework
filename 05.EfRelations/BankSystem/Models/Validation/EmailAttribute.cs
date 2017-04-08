using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validation
{
    public class EmailAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            string email = value.ToString();
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            return email.Contains('@');
        }
    }
}
