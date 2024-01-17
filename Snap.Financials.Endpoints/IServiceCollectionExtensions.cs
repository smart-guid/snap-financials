using Microsoft.Extensions.DependencyInjection;
using Snap.Financials.Endpoints.Endpoints;

namespace Snap.Financials.Endpoints;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services.AddSingleton<IEndpoint, CustomerEndpoints>();


        return services;
    }
}

