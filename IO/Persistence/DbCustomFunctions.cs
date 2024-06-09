using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public static class DbCustomFunctions
{
    public static DateTime DateTrunc(string type, DateTime date)
        => throw new NotSupportedException();

    public static DateTime DateTrunc(string type, DateTimeOffset date)
        => throw new NotSupportedException();

    public static DateTime TimeZone(string timezone, DateTimeOffset date)
        => throw new NotSupportedException();

    public static DateTime Greatest(DateTimeOffset date1, DateTimeOffset date2)
        => throw new NotSupportedException();

    public static DateTime Least(DateTimeOffset date1, DateTimeOffset date2)
        => throw new NotSupportedException();

    public static int Mod(int value, int divisor)
        => throw new NotSupportedException();
}

public class DateTruncTypes
{
    public const string Day = "day";
    public const string Hour = "hour";
    public const string Month = "month";
    public const string Year = "year";
}

public static class ModelBuilderExtensions
{
    public static void MapDbFunctions(this ModelBuilder modelBuilder)
    {
        modelBuilder.HasDbFunction(
                typeof(DbCustomFunctions).GetMethod(nameof(DbCustomFunctions.DateTrunc),
                    new[] { typeof(string), typeof(DateTime), })!)
            .HasName("date_trunc");

        modelBuilder.HasDbFunction(
                typeof(DbCustomFunctions).GetMethod(nameof(DbCustomFunctions.DateTrunc),
                    new[] { typeof(string), typeof(DateTimeOffset), })!)
            .HasName("date_trunc");

        modelBuilder.HasDbFunction(
                typeof(DbCustomFunctions).GetMethod(nameof(DbCustomFunctions.Greatest),
                    new[] { typeof(DateTimeOffset), typeof(DateTimeOffset), })!)
            .HasName("greatest");

        modelBuilder.HasDbFunction(
                typeof(DbCustomFunctions).GetMethod(nameof(DbCustomFunctions.Least),
                    new[] { typeof(DateTimeOffset), typeof(DateTimeOffset), })!)
            .HasName("least");

        modelBuilder.HasDbFunction(
                typeof(DbCustomFunctions).GetMethod(nameof(DbCustomFunctions.TimeZone),
                    new[] { typeof(string), typeof(DateTimeOffset), })!)
            .HasName("timezone");
        modelBuilder.HasDbFunction(
                typeof(DbCustomFunctions).GetMethod(nameof(DbCustomFunctions.Mod),
                    new[] {typeof(int), typeof(int),})!)
            .HasName("mod");
    }
}