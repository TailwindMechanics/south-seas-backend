//path: src\Schema\Columns\Transform.cs

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
                .Property("ColumnId")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Entity<SceneRow>()
                .Property("TransformColumnId")
                .HasColumnName("transform");

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
}