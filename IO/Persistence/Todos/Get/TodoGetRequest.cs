using Infrastructure.Common;

namespace Infrastructure.Persistence.Todos.Get;

public abstract class TodoGetRequest : GetRequest
{
    public record ById(int Id) : SingleResponse;

    public record All : ListResponse;

    public record ByIsCompleted(bool IsCompleted) : ListResponse;
}