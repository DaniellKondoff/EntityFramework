using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CreateUser.Models
{
    public partial class User
    {
        
        private string password;
        private string email;

        [Key]
        [Range(0, Int32.MaxValue)]
        public long Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (!this.CheckLowerLetter(value) || !this.CheckUpperLetter(value)|| !this.CheckDigit(value) || !this.CheckSpecialSymbol(value))
                {
                    throw new ArgumentException("The password is not allowed");
                }
                this.password = value;
            }
        }

        [Required]
        public string Email
        {
            get { return this.email; }
            set
            {
                if (!this.EmailIsValid(value))
                {
                    throw new ArgumentException("Error! Email is not in valid format");
                }
                this.email = value;
            }
        }

        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
