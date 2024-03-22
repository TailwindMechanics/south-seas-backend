//path: src\Schema\Database\Entity.cs

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

using SouthSeas.Schema.Engine;

namespace SouthSeas.Schema.Database
{
    [Table("scene_main")]
    public class Entity
    {
        [NotMapped]
        public Transform Transform { get; set; } = new Transform();

        [NotMapped]
        public Movement? Movement { get; set; }

        [Key, Column("id", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column("tags", Order = 1)]
        public string[]? Tags { get; set; }

        [Column("transform", Order = 2)]
        public string TransformJson
        {
            get => JsonConvert.SerializeObject(Transform);
            set => Transform = JsonConvert.DeserializeObject<Transform>(value)
                ?? new Transform();
        }

        [Column("movement", Order = 3)]
        public string? MovementJson
        {
            get => JsonConvert.SerializeObject(Movement);
            set => Movement = value != null ? JsonConvert.DeserializeObject<Movement>(value) : null;
        }

        [Column("created_at", Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at", Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}
