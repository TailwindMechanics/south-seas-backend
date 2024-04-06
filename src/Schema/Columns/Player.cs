//path: src\Schema\Columns\Player.cs

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Core;

namespace SouthSeas.Schema.Columns
{
    [Table("player")]
    public class Player : SceneColumn
    {
        [Column("name")]
        public string Name { get; set; } = "Untitled";

        public override void Init(ModelBuilder builder)
        {
            builder.Entity<Player>()
                .Property(nameof(Name))
                .HasDefaultValue("Untitled Player");
        }
    }
}