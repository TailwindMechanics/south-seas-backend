//path: src\Schema\Columns\Car.cs

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using SouthSeas.Schema.Core;

namespace SouthSeas.Schema.Columns
{
    [Table("car")]
    public class Car : SceneColumn
    {
        public string Name { get; set; } = "Untitled";

        public override void Init(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .Property("ColumnId")
                .HasDefaultValueSql("gen_random_uuid()");

            // builder.Entity<Car>()
            //     .Property("CarColumnId")
            //     .HasColumnName("car");

            builder.Entity<Car>()
                .Property(nameof(Name))
                .HasDefaultValue("Untitled Car");
        }
    }
}