using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.GringotsDB.Models
{
    public class WizardDeposit
    {

        public long Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Age{ get; set; }
        [StringLength(100)]
        public string MagicWandCreator  { get; set; }
        public int MagicWandSize { get; set; }

        [StringLength(20)]
        public string DepositGroup  { get; set; }
        public DateTime DepositStartDate  { get; set; }
        public decimal DepositAmount { get; set; }
        public double DepositInterest { get; set; }
        public double DepositCharge { get; set; }
        public DateTime DepositExpirationDate { get; set; }
        public bool IsDepositExpired  { get; set; }


    }
}
