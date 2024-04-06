//path: src\Schema\Core\AppDbContext.cs

using Microsoft.EntityFrameworkCore;

namespace SouthSeas.Schema.Core
{
    public class AppDbContext : DbContext
    {
        // dotnet ef migrations add Scene_1_M_1
        // dotnet ef database update
        // DROP TABLE IF EXISTS scene_5, __EFMigrationsHistory, bench, car, movement, player, transform;

        public DbSet<SceneRow> SceneRows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine("Configuring DbContext options...");
            var connectionString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION_STRING");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Console.WriteLine("OnModelCreating...");
            base.OnModelCreating(builder);

            Activator.CreateInstance<SceneRow>()?.Init(builder);
        }
    }
}
