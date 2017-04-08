using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OldetMemberFamaly
{
   public class Famaly
    {
        public List<Person> famalyCollection;

        public Famaly(List<Person> famalyCollection=null)
        {
            if (famalyCollection==null)
            {
                this.famalyCollection = new List<Person>();
            }
            else
            {
                this.famalyCollection = famalyCollection;
            }
        }

        public void AddMember(Person member)
        {
            
            this.famalyCollection.Add(member);
        }

        public void GetOldestMember()
        {
            Person OldestMember =famalyCollection.OrderByDescending(m => m.Age).First();
            Console.WriteLine($"{OldestMember.Name} {OldestMember.Age}");
        }
    }
}
