using Microsoft.EntityFrameworkCore;
using PrimeNet.Domain;

namespace PrimeNet.Infrastructure
{
    public class CompanyDbContext : DbContext
    {
        private static string _connStr = @" Server=127.0.0.1,1433;Database=PrimeNet;User Id=SA;Password=p@55W0rd;TrustServerCertificate=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connStr)
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },
                    Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(m => m.Movies)
                .WithOne(m => m.Company)
                .HasForeignKey(m => m.CompanyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Movie>()
                .HasMany(p => p.Actors)
                .WithMany(t => t.Movies)
                .UsingEntity<MovieActor>(
                    pt => pt.HasKey(e => new { e.ActorId, e.MovieId })
                );
        }

        public DbSet<Company>? Companiess { get; set; }

        public DbSet<Movie>? Movies { get; set; }
    }
}