using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelationsDemo.Models
{
    public class Address
    {
        [Key]
        [ForeignKey("Student")]
        public int Id { get; set; }
        public string Text { get; set; }
        public Student Student { get; set; }
    }
}
