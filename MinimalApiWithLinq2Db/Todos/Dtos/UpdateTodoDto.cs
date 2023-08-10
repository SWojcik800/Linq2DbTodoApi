using System.ComponentModel.DataAnnotations;

namespace MinimalApiWithLinq2Db.Todos.Dtos
{
    public sealed class UpdateTodoDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
