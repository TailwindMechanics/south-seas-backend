//path: src\Schema\Player.cs

using System.ComponentModel.DataAnnotations.Schema;

namespace SouthSeas.Schema
{
    [Table("player")]
    public class Player : TableEntity
    {
        public string Name { get; set; } = "Untiled";
    }
}