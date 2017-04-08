namespace FootballDB.Data
{
    using Migrations;
    using Models;
    using ModelsConfiguration;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FootbalContext : DbContext
    {

        public FootbalContext()
            : base("name=FootbalContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FootbalContext,Configuration>());
        }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Color> Colors { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Continent> Continents { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Position> Position { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }

        public virtual DbSet<CompetitionType> CompetitionType { get; set; }

        public virtual DbSet<Bet> Bets { get; set; }

        public virtual DbSet<BetGames> BetGames { get; set; }

        public DbSet<ResultPrediction> ResultPredictions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeamConfiguration());
            modelBuilder.Configurations.Add(new TownConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new PositionConfiguration());
            modelBuilder.Configurations.Add(new PlayerConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new BetGamesConfiguration());
            base.OnModelCreating(modelBuilder);

        }

    }

}