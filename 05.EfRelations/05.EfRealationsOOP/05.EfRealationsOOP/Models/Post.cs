using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationsDemo.Models
{
    public class Post
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
