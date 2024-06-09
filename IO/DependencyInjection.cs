using Infrastructure.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class IODependencyInjection
{
    public static IServiceCollection AddIO(this IServiceCollection services, IConnectionSettings connectionSettings)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionSettings.DbConnectionString, o => { o.MigrationsAssembly(typeof(IConnectionSettings).Assembly.FullName); })
                .EnableSensitiveDataLogging(connectionSettings.IsDevelopment)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        return services;
    }
}