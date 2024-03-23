//path: src\SchemaGen\AppDbContext.cs

using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema;

namespace SouthSeas.SchemaGen
{
    public class AppDbContext() : DbContext
    {
        // dotnet ef migrations add InitialCreate
        // dotnet ef database update

        public DbSet<SceneRow> SceneRows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION_STRING");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SceneRow>();
        }
    }
}
