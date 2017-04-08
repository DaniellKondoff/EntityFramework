using EFRelationAdvance.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRelationAdvance.ModelConfigurations
{
   public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("People");

            this.HasKey(u => u.Key);
            this.Property(u => u.Alias)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
            this.Ignore(u => u.CurrentSessionId);

            //Maping Self-Table
            this.HasMany(u => u.FriendRequestMade)
                .WithMany(u => u.FriendRequestAccepted)
                .Map(m =>
                {
                    m.ToTable("UserFriends");
                    m.MapLeftKey("RequestedUserId");
                    m.MapRightKey("AcceptedUserId");
                });

        }
    }
}
