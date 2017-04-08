using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photography.Models.Validation
{
    public class MinValueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                int minValue = int.Parse(value.ToString());
                if (minValue<100)
                {
                    return false;
                }
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
        }
    }
}
