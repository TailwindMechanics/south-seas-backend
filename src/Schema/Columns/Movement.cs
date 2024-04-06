//path: src\Schema\Columns\Movement.cs

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Core;

namespace SouthSeas.Schema.Columns
{
    [Table("movement")]
    public class Movement : SceneColumn
    {
        public float Speed { get; set; } = 1f;

        public override void Init(ModelBuilder builder)
        {
            builder.Entity<Movement>()
                .Property("ColumnId")
                .HasDefaultValueSql("gen_random_uuid()");

            // builder.Entity<Movement>()
            //     .Property("MovementColumnId")
            //     .HasColumnName("movement");

            builder.Entity<Movement>()
                .Property(nameof(Speed))
                .HasDefaultValue(1f);
        }
    }
}