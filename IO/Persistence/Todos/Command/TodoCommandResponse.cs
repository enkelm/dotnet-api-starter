using Domain.Todo;
using Infrastructure.Common;

namespace Infrastructure.Persistence.Todos.Command;

public static class TodoCommandResponse
{
    public static async Task<int?> ResponseAsync<T>(this Task<T> request, AppDbContext db,
        CancellationToken cancellationToken) where T : CommandRequest.Request? => await (await request switch
    {
        TodoCommandRequest.Add r => Add(r, db, cancellationToken),
        _ => throw new ArgumentOutOfRangeException()
    });

    private static async Task<int?> Add(TodoCommandRequest.Add request, AppDbContext db,
        CancellationToken cancellationToken)
    {
        var newTodo = new Todo
        {
            Title = request.Title,
            DueBy = request.DueBy,
            IsComplete = request.IsCompleted
        };
        db.Todos.Add(newTodo);

        try
        {
            await db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            return null;
        }

        return newTodo.Id;
    }
}