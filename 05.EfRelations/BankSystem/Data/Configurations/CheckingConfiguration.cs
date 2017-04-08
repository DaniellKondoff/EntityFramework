using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    class CheckingConfiguration : EntityTypeConfiguration<ChekingAccount>
    {
        public CheckingConfiguration()
        {
            this.HasKey(a => a.Id);

            this.Property(a => a.AccountNumber).IsRequired();

            this.HasRequired(a => a.User).WithMany(u => u.CheckingAccounts).HasForeignKey(a => a.UserId);

        }
    }
}
