using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Attribute
{
    public class CustomMinLenghtAttribute : ValidationAttribute
    {
        public int MinLenghtValue { get; set; }
        public override bool IsValid(object value)
        {
            string valueAsString = (string)value;
            if (valueAsString.Length<this.MinLenghtValue)
            {
                return false;
            }

            return true;
        }
    }
}
