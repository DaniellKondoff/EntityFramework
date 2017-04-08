using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class SavinConfiguration : EntityTypeConfiguration<SavingAccount>
    {
        public SavinConfiguration()
        {
            this.HasKey(a => a.Id);

            // Set required properties.
            this.Property(a => a.AccountNumber).IsRequired();

            this.HasRequired(a => a.User).WithMany(u => u.SavingAccounts).HasForeignKey(a => a.UserId);
          
        }
    }
}
