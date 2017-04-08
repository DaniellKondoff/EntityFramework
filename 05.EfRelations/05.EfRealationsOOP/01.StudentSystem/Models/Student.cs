using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
   public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
            this.Homeworks = new HashSet<Homework>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public DateTime BirthDay { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks  { get; set; }
    }
}
