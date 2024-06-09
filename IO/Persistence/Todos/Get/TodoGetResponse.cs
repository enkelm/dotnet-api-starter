using System.Collections.Immutable;
using Domain.Common;
using Infrastructure.Common;

namespace Infrastructure.Persistence.Todos.Get;

public static class TodoGetResponse
{
    public static TodoResponse? Response(this GetRequest.SingleResponse request, AppDbContext db) => request switch
    {
        TodoGetRequest.ById r =>
            db.Todos
                .Where(x => x.Id.Equals(r.Id))
                .Select(x => new TodoResponse(x.Id, x.Title, x.DueBy, x.IsComplete))
                .FirstOrDefault(),
        _ => throw new ArgumentOutOfRangeException()
    };

    public static ImmutableList<TodoResponse>? Response(this GetRequest.ListResponse request, AppDbContext db) =>
        request switch
        {
            TodoGetRequest.All =>
                db.Todos
                    .Select(x => new TodoResponse(x.Id, x.Title, x.DueBy, x.IsComplete))
                    .ToImmutableList()
                    .ToNullable(),
            TodoGetRequest.ByIsCompleted r =>
                db.Todos
                    .Where(x => x.IsComplete.Equals(r.IsCompleted))
                    .Select(x => new TodoResponse(x.Id, x.Title, x.DueBy, x.IsComplete))
                    .ToImmutableList()
                    .ToNullable(),
            _ => throw new ArgumentOutOfRangeException()
        };
}

public record TodoResponse(int Id, string? Title, DateOnly? DueBy, bool IsComplete);