//path: src\Schema\Car.cs

using System.ComponentModel.DataAnnotations.Schema;

namespace SouthSeas.Schema
{
    [Table("car")]
    public class Car : TableEntity
    {
        public string Name { get; set; } = "Untiled";
    }
}