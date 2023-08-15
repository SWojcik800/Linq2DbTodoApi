using LinqToDB;
using LinqToDB.Data;
using MinimalApiWithLinq2Db.Commons;
using MinimalApiWithLinq2Db.Database;
using MinimalApiWithLinq2Db.Todos.Dtos;

namespace MinimalApiWithLinq2Db.Todos
{
    public static class TodoEndpoints
    {
        public static void AddTodoEndpoints(this WebApplication app)
        {
            app.MapGet("/todos", async (TodoDbConnection db, int offset, int limit) =>
            {
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

            app.MapGet("/todos/getAll", async (TodoDbConnection db) =>
            {
                var todos = await db.Todos
                .LoadWith(t => t.Status)
                .OrderBy(t => t.Id)
                .ToListAsync();
                
                var totalCount = todos.Count();
                var pagedResult = new PagedResult<Todo>(totalCount, todos);

                return Results.Ok(pagedResult);

            });

            app.MapGet("/todos/{id}", async (TodoDbConnection db, int id) =>
            {
                var todo = await db.Todos.LoadWith(t => t.Status)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (todo is null)
                    return Results.NotFound(id);

                return Results.Ok(todo);

            });

            app.MapPost("/todos", async (TodoDbConnection db, CreateTodoDto dto) =>
            {
                var createdTodoId = await db.InsertWithInt32IdentityAsync<Todo>(new Todo
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    StatusId = dto.StatusId
                });

                return Results.Created("/todos/", createdTodoId);

            });

            app.MapPut("/todos/", async (TodoDbConnection db, UpdateTodoDto dto) =>
            {
                await db.UpdateAsync(new Todo()
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Description = dto.Description,
                    StatusId = dto.StatusId
                });

                return Results.NoContent();
            });

            app.MapDelete("/todos", async (TodoDbConnection db, int id) =>
            {
                await db.Todos.DeleteAsync(t => t.Id == id);

                return Results.NoContent();
            });
        }
    }
}
