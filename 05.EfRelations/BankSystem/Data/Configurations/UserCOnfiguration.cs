using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.HasKey(u => u.Id);

            this.Property(u => u.Username).IsRequired();
            this.Property(u => u.Email).IsRequired();
            this.Property(u => u.Password).IsRequired();
           
        }
    }
}
