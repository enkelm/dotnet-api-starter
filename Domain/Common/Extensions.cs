using System.Collections.Immutable;

namespace Domain.Common;

public static class EnumerableExtensions
{
    public static ImmutableList<T>? ToNullable<T>(this ImmutableList<T> source) =>
        source is not [] ? source : null;

    public static ImmutableList<T>? ToNullable<T>(this IEnumerable<T> source) =>
        source.ToImmutableList() is var res && res is not [] ? res : null;

    public static IList<T>? ToNullable<T>(this IList<T> source) =>
        source is not [] ? source : null;
}