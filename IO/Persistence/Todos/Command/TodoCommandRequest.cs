using FluentValidation;
using Infrastructure.Common;

namespace Infrastructure.Persistence.Todos.Command;

public abstract class TodoCommandRequest : CommandRequest
{
    public record Add(string Title, DateOnly? DueBy, bool IsCompleted): Request;
    
    public class AddValidator : AbstractValidator<Add>
    {
        public AddValidator()
        {
            RuleFor(r => r.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Fill in the title");
        }
    }
}