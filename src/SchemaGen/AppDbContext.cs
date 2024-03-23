//path: src\SchemaGen\AppDbContext.cs

using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema;

namespace SouthSeas.SchemaGen
{
    public class AppDbContext : DbContext
    {
        // dotnet ef migrations add InitialCreate
        // dotnet ef database update

        public DbSet<SceneRow> SceneRows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION_STRING");
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var tableEntityTypes = GetTableEntityTypes();
            tableEntityTypes.ForEach(tableEntityType =>
            {
                builder.Entity(tableEntityType)
                    .Property("Id")
                    .HasDefaultValueSql("gen_random_uuid()");
            });

            builder.GenFloat3<Transform>("Position", [0, 0, 0]);
            builder.GenFloat3<Transform>("Rotation", [0, 0, 0]);
            builder.GenFloat3<Transform>("Scale", [1, 1, 1]);
            builder.GenString<Player>("Name", "Untitled");
            builder.GenFloat<Movement>("Speed", 1f);
            builder.GenString<Car>("Name", "Untiled");
        }

        public List<Type> GetTableEntityTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t != typeof(TableEntity) && typeof(TableEntity).IsAssignableFrom(t))
                .ToList();
        }
    }
}
