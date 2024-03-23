//path: src\Schema\Movement.cs

using System.ComponentModel.DataAnnotations.Schema;

namespace SouthSeas.Schema
{
    [Table("movement")]
    public class Movement : TableEntity
    {
        public float Speed { get; set; }
        public float Direction { get; set; }
    }
}