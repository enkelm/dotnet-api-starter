using Integration.Todo;

namespace Api.Todo;

public static class GetEndpoints
{
    public static RouteGroupBuilder AddGetTodos(this RouteGroupBuilder group)
    {
        group.MapGet("/", TodoGetHandler.All);
        group.MapGet("/{id:int}", TodoGetHandler.ById);
        group.MapGet("/{isCompleted:bool}", TodoGetHandler.ByIsCompleted);

        return group;
    }
}