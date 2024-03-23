//path: src\Schema\Transform.cs

using System.ComponentModel.DataAnnotations.Schema;

namespace SouthSeas.Schema
{
    [Table("transform")]
    public class Transform : TableEntity
    {
        [Column("position", TypeName = "real[]")]
        public float[] Position { get; set; } = [0, 0, 0];

        [Column("rotation", TypeName = "real[]")]
        public float[] Rotation { get; set; } = [0, 0, 0];

        [Column("scale", TypeName = "real[]")]
        public float[] Scale { get; set; } = [1, 1, 1];
    }
}