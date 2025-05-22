using Microsoft.EntityFrameworkCore;
using OpenMovieService.Infrastructure.DatabaseEntities;
using OpenMovieService.Infrastructure.Services;

namespace OpenMovieService.Infrastructure.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Add your entity configurations here
            configureMoviesEntity(modelBuilder);
            ConfigureRatingsEntity(modelBuilder);
        }

        public DbSet<MovieEntity> Movies { get; set; } = null!;
        public DbSet<RatingEntity> Ratings { get; set; } = null!;
        public DbSet<CachedEntryEntity> CachedEntries { get; set; } = null!;

        public void configureMoviesEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieEntity>(entity =>
            {
                entity.HasMany(r => r.Ratings)
                      .WithOne()
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        public void ConfigureRatingsEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RatingEntity>(entity =>
            {
                entity.HasOne<MovieEntity>()
                      .WithMany()
                      .HasForeignKey(r => r.MovieId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

        }
    }
}

