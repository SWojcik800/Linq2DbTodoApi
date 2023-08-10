using LinqToDB.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MinimalApiWithLinq2Db.TodoStatuses
{
    [Table("TodoStatuses")]
    public sealed class TodoStatus
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column]
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
