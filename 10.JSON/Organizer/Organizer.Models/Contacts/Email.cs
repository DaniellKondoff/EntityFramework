using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizer.Models.Contacts
{
    public class Email
    {
        public int Id { get; set; }

        public int Text { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
