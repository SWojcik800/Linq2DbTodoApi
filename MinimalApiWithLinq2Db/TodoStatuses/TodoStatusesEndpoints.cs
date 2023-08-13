using LinqToDB;
using MinimalApiWithLinq2Db.Database;

namespace Web.Api.TodoStatuses
{
    public static class TodoStatusesEndpoints
    {
        public static void AddTodoStatusesEndpoints(this WebApplication app)
        {

            app.MapGet("/todo-statuses", async (TodoDbConnection db) =>
            {
                var statuses = await db.TodoStatuses
                .ToListAsync();

                return Results.Ok(statuses);

            });
        }
    }
}
