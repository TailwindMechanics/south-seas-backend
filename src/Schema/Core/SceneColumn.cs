//path: src\Schema\Core\SceneColumn.cs

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SouthSeas.Schema.Core
{
    public abstract class SceneColumn
    {
        [Key, Column("column_id")]
        public Guid ColumnId { get; set; }

        public abstract void Init(ModelBuilder builder);
    }
}
