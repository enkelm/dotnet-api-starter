using Application;
using Infrastructure;
using Infrastructure.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Integration;

public static class DependencyInjection
{
    public static IServiceCollection AddIntegration(this IServiceCollection services, bool isDevelopment)
    {
        var connectionSettings = new ConnectionSettings(isDevelopment);

        services
            .AddIO(connectionSettings)
            .AddApplication();
        
        return services;
    }
}