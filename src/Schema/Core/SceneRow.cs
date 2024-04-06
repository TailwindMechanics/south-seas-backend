//path: src\Schema\Core\SceneRow.cs

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Columns;

namespace SouthSeas.Schema.Core
{
    [Table("scene_17")]
    public class SceneRow
    {
        [Key]
        [Column("row_id")]
        public Guid RowId { get; set; }

        public Transform? Transform { get; set; }
        public Player? Player { get; set; }
        public Bench? Bench { get; set; }
        public Movement? Movement { get; set; }
        public Car? Car { get; set; }

        public void Init(ModelBuilder builder)
        {
            builder.Entity<SceneRow>()
                .Property(e => e.RowId)
                .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}
