using FluentValidation;
using FluentValidation.Results;
using Infrastructure.Common;
using Infrastructure.Persistence.Todos.Command;
using Microsoft.Extensions.Logging;

namespace Integration.Common;

public static class Extensions
{
    public static async Task<TIn?> ValidateAsync<TIn, TValidator>(this TIn? source, TValidator validator,
        CancellationToken cancellationToken = default)
        where TIn : CommandRequest.Request
        where TValidator : AbstractValidator<TIn>
        => source is not null
            ? await validator.ValidateAsync(source, cancellationToken) is var validation && validation.IsValid
                ? source
                : throw new ValidationException(validation.Errors)
            : throw new ValidationException([new ValidationFailure(nameof(TIn), "No request body")]);
}