using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Models.Contacts
{
    public class Person
    {
        public Person()
        {
            this.Emails = new HashSet<Email>();
            this.Phones = new HashSet<Phone>();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
