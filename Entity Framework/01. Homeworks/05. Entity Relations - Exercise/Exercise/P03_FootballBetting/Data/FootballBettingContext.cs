namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
		public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }
		
        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<PlayerStatistic>()
                 .HasKey(k => new { k.GameId, k.PlayerId });

            modelBuilder
                .Entity<Team>(entity =>
                {
                    entity.HasKey(e => e.TeamId);

                    entity
                    .HasOne(e => e.PrimaryKitColor)
                    .WithMany(pc => pc.PrimaryKitTeams)
                    .HasForeignKey(k => k.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);

                    entity
                    .HasOne(e => e.SecondaryKitColor)
                    .WithMany(pc => pc.SecondaryKitTeams)
                    .HasForeignKey(k => k.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<Town>(entity =>
                {
                    entity.HasKey(k => k.TownId);

                    entity
                    .HasOne(e => e.Country)
                    .WithMany(t => t.Towns)
                    .HasForeignKey(k => k.CountryId);
                });

            modelBuilder
                .Entity<Game>(entity =>
                {
                    entity.HasKey(e => e.GameId);

                    entity
                    .HasOne(e => e.HomeTeam)
                    .WithMany(p => p.HomeGames)
                    .HasForeignKey(k => k.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

                    entity
                    .HasOne(e => e.AwayTeam)
                    .WithMany(p => p.AwayGames)
                    .HasForeignKey(k => k.AwayTeamId)
                    .OnDelete(DeleteBehavior.Restrict);
                });
        }
    }
}