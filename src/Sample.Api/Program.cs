using Sample.Api.Contracts.Responses;
using Sample.Api.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/todos", ([FromServices] ITodoRepository todoRepository) =>
{
    var todos = todoRepository.GetAll();
    return todos.Select(t => new TodoResponse { Id = t.Id, Description = t.Description });
});

app.MapGet("/todos/{todoId}", (
    [FromRoute] int todoId,
    [FromServices] ITodoRepository todoRepository) =>
{
    var todo = todoRepository.GetById(todoId);
    if (todo is null)
    {
        return Results.NotFound();
    }

    return new TodoResponse
    {
        Id = todo.Id,
        Description = todo.Description
    };
});

await app.RunAsync();
