using MinimalApiWithLinq2Db.Database;
using MinimalApiWithLinq2Db.Todos;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var settings = new TodoDbConnectionSettings(configuration.GetConnectionString("Default"));
LinqToDB.Data.DataConnection.DefaultSettings = settings;

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
