using System.Collections.Immutable;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Todos.Get;

namespace Integration.Todo;

public static class TodoGetHandler
{
    public static TodoResponse? ById(int id, AppDbContext db)
        => new TodoGetRequest.ById(id).Response(db);

    public static ImmutableList<TodoResponse>? All(AppDbContext db)
        => new TodoGetRequest.All().Response(db);

    public static ImmutableList<TodoResponse>? ByIsCompleted(bool isCompleted, AppDbContext db)
        => new TodoGetRequest.ByIsCompleted(isCompleted).Response(db);
}