//path: src\Schema\Columns\Player.cs

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Core;

namespace SouthSeas.Schema.Columns
{
    [Table("player")]
    public class Player : SceneColumn
    {
        [Column("name")]
        public string Name { get; set; } = "Untitled";

        public override void Init(ModelBuilder builder)
        {
            builder.Entity<Player>()
                .Property(nameof(Name))
                .HasDefaultValue("Untitled Player");
        }
    }
}//path: src\Schema\Columns\Transform.cs

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Core;

namespace SouthSeas.Schema.Columns
{
    [Table("transform")]
    public class Transform : SceneColumn
    {
        [Column("position", TypeName = "real[]")]
        public float[] Position { get; set; } = [0, 0, 0];

        [Column("rotation", TypeName = "real[]")]
        public float[] Rotation { get; set; } = [0, 0, 0];

        [Column("scale", TypeName = "real[]")]
        public float[] Scale { get; set; } = [1, 1, 1];

        public override void Init(ModelBuilder builder)
        {
            builder.Entity<Transform>()
                .Property(nameof(Position))
                .HasDefaultValue(new float[] { 0, 0, 0 });
            builder.Entity<Transform>()
                .Property(nameof(Rotation))
                .HasDefaultValue(new float[] { 0, 0, 0 });
            builder.Entity<Transform>()
                .Property(nameof(Scale))
                .HasDefaultValue(new float[] { 1, 1, 1 });
        }
    }
}//path: src\Schema\Core\AppDbContext.cs

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
//path: src\Schema\Core\SceneColumn.cs

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SouthSeas.Schema.Core
{
    public abstract class SceneColumn
    {
        [Key, Column("column_id")]
        public Guid ColumnId { get; set; }

        public abstract void Init(ModelBuilder builder);
    }
}
//path: src\Schema\Core\SceneRow.cs

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Columns;

namespace SouthSeas.Schema.Core
{
    [Table("cards_scene_7")]
    public class SceneRow
    {
        [Key]
        [Column("row_id")]
        public Guid RowId { get; set; }

        [Column("tags")]
        public string[]? Tags { get; set; } = [];
        [Column("suit")]
        public string? Suit { get; set; } = null;
        [Column("rank")]
        public string? Rank { get; set; } = null;

        public Player? Owner { get; set; }
        public Player? Player { get; set; }
        public Transform? Transform { get; set; }

        [Column("image_url")]
        public string? ImageUrl { get; set; } = null;

        public void Init(ModelBuilder builder)
        {
            Console.WriteLine("SceneRow Init()");

            InitScene(builder);
            InitColumns(builder);
        }

        void InitScene(ModelBuilder builder)
        {
            builder.Entity<SceneRow>()
                .Property(e => e.RowId)
                .HasDefaultValueSql("gen_random_uuid()");
        }

        void InitColumns(ModelBuilder builder)
        {
            var props = typeof(SceneRow).GetProperties().ToList();
            foreach (var prop in props)
            {
                if (!IsSceneColumn(prop.PropertyType)) continue;

                builder.Entity<SceneRow>()
                    .Property($"{prop.Name}ColumnId")
                    .HasColumnName(prop.Name.ToLower());
            }

            var tableEntityTypes = GetTableEntityTypes();
            foreach (var entityType in tableEntityTypes)
            {
                var instance = Activator.CreateInstance(entityType) as SceneColumn;
                builder.Entity(entityType)
                    .Property("ColumnId")
                    .HasDefaultValueSql("gen_random_uuid()");

                instance?.Init(builder);
            }
        }

        bool IsSceneColumn(Type type)
            => typeof(SceneColumn).IsAssignableFrom(type);

        List<Type> GetTableEntityTypes()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            return assemblies.SelectMany(a => a.GetTypes())
                .Where(t => t != typeof(SceneColumn) && typeof(SceneColumn).IsAssignableFrom(t))
                .ToList();
        }
    }
}
