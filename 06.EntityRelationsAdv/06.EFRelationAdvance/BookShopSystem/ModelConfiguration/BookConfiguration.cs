using BookShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopSystem.ModelConfiguration
{
    public class BookConfiguration : EntityTypeConfiguration<Book>
    {
        public BookConfiguration()
        {
            this
                .HasMany(b => b.RelatedBooks)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("RelatedBooks");
                    m.MapLeftKey("BookId");
                    m.MapRightKey("RelatedId");
                });
        }
    }
}
