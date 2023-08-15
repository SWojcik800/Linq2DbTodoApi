using System.ComponentModel.DataAnnotations;

namespace MinimalApiWithLinq2Db.Todos.Dtos
{
    public sealed class UpdateTodoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
