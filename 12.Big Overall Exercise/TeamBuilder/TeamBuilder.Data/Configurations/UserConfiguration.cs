using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.HasKey(u => u.Id);
            this.Property(u => u.Username).IsRequired().HasMaxLength(25);

            //Unique UserName
            this.Property(u => u.Username).HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                    new IndexAttribute("IX_Users_Username", 1) { IsUnique = true }));
            this.Property(u => u.FirstName).IsRequired().HasMaxLength(25);
            this.Property(u => u.LastName).IsRequired().HasMaxLength(25);
            this.Property(u => u.Password).IsRequired().HasMaxLength(30);

            this.HasMany(u => u.CreatedEvents).WithRequired(e => e.Creator).HasForeignKey(e => e.CreatorId).WillCascadeOnDelete(false);

            this.HasMany(u => u.CreatedTeams).WithRequired(t => t.Creator).HasForeignKey(t => t.CreatorId).WillCascadeOnDelete(false);

            this.HasMany(u => u.ReceivedInvitations).WithRequired(t => t.InvitedUser).HasForeignKey(t => t.InvitedUserId).WillCascadeOnDelete(false);

            this.HasMany(u => u.Teams).WithMany(t => t.Members).Map(ut =>
                {
                    ut.ToTable("UserTeams");
                    ut.MapLeftKey("UserId");
                    ut.MapRightKey("TeamId");
                });
        }
    }
}
