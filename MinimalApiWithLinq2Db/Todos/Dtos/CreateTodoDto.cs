using System.ComponentModel.DataAnnotations;

namespace MinimalApiWithLinq2Db.Todos.Dtos
{
    public sealed class CreateTodoDto
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description
        {
            get; set;
        }
        public int StatusId { get; set; }

    }
}
