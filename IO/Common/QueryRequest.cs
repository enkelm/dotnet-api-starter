namespace Infrastructure.Common;

public abstract class QueryRequest
{
    public abstract record SingleResponse;

    public abstract record ListResponse;
}