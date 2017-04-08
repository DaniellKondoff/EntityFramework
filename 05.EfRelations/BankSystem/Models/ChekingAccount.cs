using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ChekingAccount
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }
        public decimal Fee { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }

    }
}
