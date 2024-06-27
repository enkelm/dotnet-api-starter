namespace Api.Todo;

public static class TodoEndpoints
{
    public static WebApplication AddTodo(this WebApplication app)
    {
        var routeGroup = app.MapGroup("/todos");

        routeGroup
            .AddGetTodos()
            .AddPostTodos();

        return app;
    }
}