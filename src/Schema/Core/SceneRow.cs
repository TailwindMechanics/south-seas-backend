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
