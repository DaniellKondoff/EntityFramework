using ProductsShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.ModelConfiguration
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(u => u.FirstName).IsOptional();
            this.Property(u => u.Age).IsOptional();
            this.HasMany(p => p.ProductsSold)
                .WithRequired(u => u.Seller)
                .HasForeignKey(p => p.SellerId);
            this.HasMany(p => p.ProductsBought)
                .WithOptional(u => u.Buyer)
                .HasForeignKey(p => p.BuyerId);

            this.HasMany(u => u.Friends)
                .WithMany(f => f.Users)
                .Map(uf => 
                {
                    uf.ToTable("UserFriends");
                    uf.MapLeftKey("UserId");
                    uf.MapRightKey("FriendId");
                });

        }
    }
}
