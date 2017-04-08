using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationAdvance.Models
{
   public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int ChirpRefId { get; set; }
        public virtual Chirp Chirp { get; set; }
    }
}
