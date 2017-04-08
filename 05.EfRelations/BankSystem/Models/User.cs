using Models.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int Id { get; set; }

        [UserNameAtrribute(3,ContainsSpecialSymbol =true,ErrorMessageResourceName ="Incorect Username")]
        public string Username { get; set; }

        [Password(6,ContainsDigit =true,ContainsLowercase =true,ContainsUppercase =true,ErrorMessageResourceName="Incorect Password")]
        public string Password { get; set; }

        [Email]
        public string Email { get; set; }

        public virtual ICollection<SavingAccount> SavingAccounts { get; set; }

        public virtual ICollection<ChekingAccount> CheckingAccounts { get; set; }
    }
}
