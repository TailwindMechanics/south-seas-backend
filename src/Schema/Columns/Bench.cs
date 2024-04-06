//path: src\Schema\Columns\Bench.cs

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Core;

namespace SouthSeas.Schema.Columns
{
    [Table("bench")]
    public class Bench : SceneColumn
    {
        public string Name { get; set; } = "Untitled";

        public override void Init(ModelBuilder builder)
        {
            builder.Entity<Bench>()
                .Property("ColumnId")
                .HasDefaultValueSql("gen_random_uuid()");

            builder.Entity<Bench>()
                .Property(e => e.ColumnId)
                .HasColumnName("bench");

            builder.Entity<Bench>()
                .Property(nameof(Name))
                .HasDefaultValue("Untitled Bench");
        }
    }
}