//path: src\Schema\Core\AppDbContext.cs

using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Core;

namespace SouthSeas.Schema.Utils
{
    public class AppDbContext : DbContext
    {
        // dotnet ef migrations add Scene_1_M_1
        // dotnet ef database update
        // DROP TABLE IF EXISTS scene_5, __EFMigrationsHistory, bench, car, movement, player, transform;

        public DbSet<SceneRow> SceneRows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION_STRING");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Activator.CreateInstance<SceneRow>()?.Init(builder);

            var tableEntityTypes = GetTableEntityTypes();
            foreach (var entityType in tableEntityTypes)
            {
                var instance = Activator.CreateInstance(entityType) as SceneColumn;
                instance?.Init(builder);
            }
        }

        public List<Type> GetTableEntityTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t != typeof(SceneColumn) && typeof(SceneColumn).IsAssignableFrom(t))
                .ToList();
        }
    }
}
