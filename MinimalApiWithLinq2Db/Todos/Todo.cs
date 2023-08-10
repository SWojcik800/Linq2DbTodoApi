using LinqToDB.Mapping;
using MinimalApiWithLinq2Db.TodoStatuses;
using System.ComponentModel.DataAnnotations;

namespace MinimalApiWithLinq2Db.Todos
{
    [Table(Name = "Todos")]
    public sealed class Todo
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Column]
        [MaxLength(250)]
        public string Description { get; set; }
        [Column]
        public int StatusId { get; set; }
        [LinqToDB.Mapping.Association(ThisKey = "StatusId", OtherKey = "Id", CanBeNull = false)]
        public TodoStatus Status { get; set; }

    }
}
