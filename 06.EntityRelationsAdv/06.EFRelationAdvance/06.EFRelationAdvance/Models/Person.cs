using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationAdvance.Models
{
    public class Person
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public int? PlaceOfBirthId { get; set; }
        public int? CurrentResidenseId { get; set; }
        public virtual Town PlaceOfBirth { get; set; }

        public virtual Town CurrentResidense { get; set; }
    }
}
