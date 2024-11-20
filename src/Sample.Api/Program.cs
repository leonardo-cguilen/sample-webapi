using Sample.Api.Contracts.Responses;
using Sample.Api.Repositories;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

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

await app.RunAsync();
