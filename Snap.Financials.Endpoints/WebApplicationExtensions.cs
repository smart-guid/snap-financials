using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Snap.Financials.Endpoints.Endpoints;

namespace Snap.Financials.Endpoints;

public static class WebApplicationExtensions
{
    public static WebApplication RegisterRoutes(this WebApplication app)
    {
        var endpoints = app.Services.GetServices<IEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.MapEndpoints(app);
        }

        return app;
    }
}
