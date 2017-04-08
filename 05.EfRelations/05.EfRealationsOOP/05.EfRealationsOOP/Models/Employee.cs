using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationsDemo.Models
{
   public class Employee
    {
        public Employee()
        {
            this.Subordinates = new HashSet<Employee>();
            this.ProjectEmployees = new HashSet<ProjectEmployees>();
        }
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        //Self Relationship
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Subordinates { get; set; }

        public virtual ICollection<ProjectEmployees> ProjectEmployees { get; set; }
    }
}
