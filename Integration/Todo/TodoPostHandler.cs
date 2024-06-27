using FluentValidation;
using Infrastructure.Common;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Todos.Command;
using Integration.Common;
using Microsoft.Extensions.Logging;

namespace Integration.Todo;

public static class TodoPostHandler
{
    public static async Task<int?> AddAsync(TodoCommandRequest.Add request, AppDbContext db,
        ILoggerFactory loggerFactory, CancellationToken cancellationToken = default)
    {
        try
        {
            return await request
                .ValidateAsync(new TodoCommandRequest.AddValidator(), cancellationToken)
                .ResponseAsync(db, cancellationToken);
        }
        catch (Exception e)
        {
            ILogger logger = e switch
            {
                ValidationException => loggerFactory.CreateLogger<TodoCommandRequest.AddValidator>(),
                _ => loggerFactory.CreateLogger<CommandRequest.Request>()
            };
            
            logger.Log(LogLevel.Error, e, e.Message);
            return null;
        }
    }
}