using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Validation
{
    public class UserNameAtrribute : ValidationAttribute
    {
        private const string SpecialSymbols = "!@#$%^&*()_+<>,.?";
        private int minLength;
        public UserNameAtrribute(int minLength)
        {
            this.minLength = minLength;
        }

        public bool ContainsSpecialSymbol { get; set; }
        public override bool IsValid(object value)
        {
            string username = value.ToString();
            if (username.Length<minLength)
            {
                return false;
            }
            if (this.ContainsSpecialSymbol && username.Any(c=>SpecialSymbols.Contains(c)))
            {
                return false;
            }
            if (char.IsDigit(username[0]))
            {
                return false;
            }
            return true;
        }
    }
}
