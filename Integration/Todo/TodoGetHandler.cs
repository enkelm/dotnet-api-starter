using System.Collections.Immutable;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Todos.Query;

namespace Integration.Todo;

public static class TodoGetHandler
{
    public static TodoResponse? ById(int id, AppDbContext db)
        => new TodoQueryRequest.ById(id).Response(db);

    public static ImmutableList<TodoResponse>? All(AppDbContext db)
        => new TodoQueryRequest.All().Response(db);

    public static ImmutableList<TodoResponse>? ByIsCompleted(bool isCompleted, AppDbContext db)
        => new TodoQueryRequest.ByIsCompleted(isCompleted).Response(db);
}