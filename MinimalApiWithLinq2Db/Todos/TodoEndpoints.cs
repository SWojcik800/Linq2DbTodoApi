using LinqToDB;
using LinqToDB.Data;
using MinimalApiWithLinq2Db.Commons;
using MinimalApiWithLinq2Db.Database;
using MinimalApiWithLinq2Db.Todos.Dtos;
using MinimalApiWithLinq2Db.TodoStatuses;

namespace MinimalApiWithLinq2Db.Todos
{
    public static class TodoEndpoints
    {
        public static void AddTodoEndpoints(this WebApplication app)
        {
            app.MapGet("/todos", async (int offset, int limit) =>
            {
                using var db = new TodoDbConnection();
                var todos = await db.Todos
                .LoadWith(t => t.Status)
                .OrderBy(t => t.Id)
                .Skip(offset)
                .Take(limit)
                .ToListAsync();

                var totalCount = await db.Todos.CountAsync();
                var pagedResult = new PagedResult<Todo>(totalCount, todos);

                return Results.Ok(pagedResult);

            });

            app.MapGet("/todos/{id}", async (int id) =>
            {
                using var db = new TodoDbConnection();
                var todo = await db.Todos.LoadWith(t => t.Status)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (todo is null)
                    return Results.NotFound(id);

                return Results.Ok(todo);

            });

            app.MapPost("/todos", async (CreateTodoDto dto) =>
            {
                using var db = new TodoDbConnection();
                var createdTodoId = await db.InsertWithInt32IdentityAsync<Todo>(new Todo
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    StatusId = dto.StatusId
                });

                return Results.Created("/todos/", createdTodoId);

            });

            //app.MapPost("/todos/bulk-copy", async () =>
            //{
            //    var todos = Enumerable.Range(0, 100000).Select(i => new Todo()
            //    {
            //        Name = $"test{i}",
            //        Description = $"testDesc{i}"
            //    });


            //    using var db = new TodoDbConnection();

            //    await db.BulkCopyAsync(todos);
            //    return Results.Ok();

            //});

            app.MapPut("/todos/", async (UpdateTodoDto dto) =>
            {
                using var db = new TodoDbConnection();
                await db.UpdateAsync(new Todo()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    StatusId = dto.StatusId
                });

                return Results.NoContent();
            });

            app.MapDelete("/todos", async (int id) =>
            {
                using var db = new TodoDbConnection();

                await db.Todos.DeleteAsync(t => t.Id == id);

                return Results.NoContent();
            });
        }
    }
}
