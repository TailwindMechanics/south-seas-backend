//path: src\Schema\Transform.cs

using System.ComponentModel.DataAnnotations.Schema;

namespace SouthSeas.Schema
{
    [Table("transform")]
    public class Transform : TableEntity
    {
        [Column("position", TypeName = "real[]")]
        public float[] Position { get; set; } = new float[3];

        [Column("rotation", TypeName = "real[]")]
        public float[] Rotation { get; set; } = new float[3];

        [Column("scale", TypeName = "real[]")]
        public float[] Scale { get; set; } = new float[3];
    }
}