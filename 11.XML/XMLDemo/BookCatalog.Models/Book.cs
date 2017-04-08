using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Models
{
     public class Book
    {
        public Book()
        {
            this.Genres = new HashSet<Genre>();
        }
        public int Id { get; set; }

        public string RefNumber { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Description { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
    }
}
