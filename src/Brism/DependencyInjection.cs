using Microsoft.Extensions.DependencyInjection;

namespace Brism;

public static class DependencyInjection
{
    public static IServiceCollection AddBrism(this IServiceCollection services)
    {
        services.AddScoped<PrismJsInterop>();

        return services;
    }
}