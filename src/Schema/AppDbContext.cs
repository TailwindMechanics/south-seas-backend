//path: src\Schema\AppDbContext.cs

using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Database;

namespace SouthSeas.Schema
{
    public class AppDbContext() : DbContext
    {
        // dotnet ef migrations add InitialCreate
        // dotnet ef database update

        public DbSet<Entity> Entities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION_STRING");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Entity>(entity =>
            {
                // Configure column types
                entity.Property(e => e.TransformJson).HasColumnType("jsonb");
                entity.Property(e => e.MovementJson).HasColumnType("jsonb");
                entity.Property(s => s.Tags).HasColumnType("text[]");
            });
        }
    }
}
