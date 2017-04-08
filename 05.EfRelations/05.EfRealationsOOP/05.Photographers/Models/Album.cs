using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photographers.Models
{
   public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Tags = new HashSet<Tag>();
            this.Photographers = new HashSet<PhotographerAlbums>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string BackgroundColor { get; set; }

        public bool isPublic { get; set; }

        //[ForeignKey("Owner")]
        //public int OwnerId { get; set; }
        //public virtual Photographer Owner { get; set; }

        public virtual ICollection<PhotographerAlbums> Photographers { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
