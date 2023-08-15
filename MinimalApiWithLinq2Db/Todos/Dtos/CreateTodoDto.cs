using System.ComponentModel.DataAnnotations;

namespace MinimalApiWithLinq2Db.Todos.Dtos
{
    public sealed class CreateTodoDto
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }

    }
}
