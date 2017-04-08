using AdvanceMapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceMapping.Dto
{
    public class ManagerDto
    {
        public ManagerDto()
        {
            this.EmployeesInCharge = new HashSet<EmployeeDto>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int EmployeesCount { get; set; }

        public virtual ICollection<EmployeeDto> EmployeesInCharge  { get; set; }
    }
}
