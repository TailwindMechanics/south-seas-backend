//path: src\Schema\SceneRow.cs

using System.ComponentModel.DataAnnotations.Schema;

namespace SouthSeas.Schema
{
    [Table("scene")]
    public class SceneRow : TableEntity
    {
        [Column("transform")]
        public Transform Transform { get; set; } = new Transform();

        [Column("player")]
        public Player? Player { get; set; }

        [Column("movement")]
        public Movement? Movement { get; set; }

        [Column("tags")]
        public Car? Car { get; set; }
    }
}
