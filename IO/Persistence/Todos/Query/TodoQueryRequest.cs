using Infrastructure.Common;

namespace Infrastructure.Persistence.Todos.Query;

public abstract class TodoQueryRequest : QueryRequest
{
    public record ById(int Id) : SingleResponse;

    public record All : ListResponse;

    public record ByIsCompleted(bool IsCompleted) : ListResponse;
}