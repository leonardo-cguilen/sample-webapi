using System.Collections.Generic;
using Sample.Api.Models;

namespace Sample.Api.Repositories;

public interface ITodoRepository
{
    Todo Add(Todo todo);

    Todo? GetById(int todoId);

    Todo[] GetAll();
}

internal sealed class TodoRepository : ITodoRepository
{
    private List<Todo> _todos = new();

    public Todo Add(Todo todo)
    {
        _todos.Add(todo);
        return todo;
    }

    public Todo? GetById(int todoId)
    {
        return _todos.Find(t => t.Id == todoId);
    }

    public Todo[] GetAll()
    {
        return _todos.ToArray();
    }
}
