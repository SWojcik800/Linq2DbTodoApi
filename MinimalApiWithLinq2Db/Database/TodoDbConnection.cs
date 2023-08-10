using LinqToDB;
using LinqToDB.Data;
using MinimalApiWithLinq2Db.Todos;
using MinimalApiWithLinq2Db.TodoStatuses;

namespace MinimalApiWithLinq2Db.Database
{
    public sealed class TodoDbConnection : DataConnection
    {
        public TodoDbConnection()
            :base ("Default")
        {

        }

        public ITable<Todo> Todos => this.GetTable<Todo>();
        public ITable<TodoStatus> TodoStatuses => this.GetTable<TodoStatus>();
    }
}
