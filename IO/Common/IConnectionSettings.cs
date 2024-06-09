namespace Infrastructure.Common;

public interface IConnectionSettings
{
    public bool IsDevelopment { get; init; }
    public string DbConnectionString { get; init; }
}

public class ConnectionSettings(bool isDevelopment) : IConnectionSettings
{
    public bool IsDevelopment { get; init; } = isDevelopment;
    public string DbConnectionString { get; init; } = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                                                    "Host=localhost;Database=dotnet-starter;Username=postgres;password=root";
}