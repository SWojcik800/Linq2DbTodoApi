using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.AspNet.Logging;
using LinqToDB.Data;
using MinimalApiWithLinq2Db.Database;
using MinimalApiWithLinq2Db.Todos;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddLinqToDBContext<TodoDbConnection>((provider, options)
            => options
                .UseSqlServer(configuration.GetConnectionString("Default"))
                .UseDefaultLogging(provider));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddTodoEndpoints();
    

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
