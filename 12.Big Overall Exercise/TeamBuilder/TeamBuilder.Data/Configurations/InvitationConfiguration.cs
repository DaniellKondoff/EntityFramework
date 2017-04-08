using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configurations
{
    class InvitationConfiguration : EntityTypeConfiguration<Invitation>
    {
        public InvitationConfiguration()
        {
            this.HasKey(e => e.Id);

            this.HasRequired(i => i.InvitedUser).WithMany(u => u.ReceivedInvitations).HasForeignKey(i=>i.InvitedUserId).WillCascadeOnDelete(false);
            this.HasRequired(i => i.Team).WithMany(t => t.Invitations).HasForeignKey(i => i.TeamId).WillCascadeOnDelete(false);
        }
    }
}
