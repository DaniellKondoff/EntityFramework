using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationsDemo.Models
{
   public class Project
    {
        public Project()
        {
            this.ProjectEmployees = new HashSet<ProjectEmployees>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProjectEmployees> ProjectEmployees { get; set; }
    }
}
