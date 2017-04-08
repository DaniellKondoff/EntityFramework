using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketsystem.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Tickets = new HashSet<Ticket>();
            this.Reviews = new HashSet<Review>();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public int HomeTownId { get; set; }
        public Town HomeTown { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        NotSpecifield
    }
}
