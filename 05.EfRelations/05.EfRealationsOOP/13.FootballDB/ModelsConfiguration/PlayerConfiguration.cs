using FootballDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDB.ModelsConfiguration
{
    class PlayerConfiguration : EntityTypeConfiguration<Player>
    {
        public PlayerConfiguration()
        {
            //this.HasMany(p => p.Games)
            //    .WithMany(g => g.Players)
            //    .Map(m =>
            //    {
            //        m.ToTable("PlayerStatistics");
            //        m.MapLeftKey("PlayerId");
            //        m.MapRightKey("GameId");
            //    });
        }
    }
}
