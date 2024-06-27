using Integration.Todo;

namespace Api.Todo;

public static class PostEndpoints
{
    public static RouteGroupBuilder AddPostTodos(this RouteGroupBuilder group)
    {
        group.MapPost("/", TodoPostHandler.AddAsync);

        return group;
    }
}