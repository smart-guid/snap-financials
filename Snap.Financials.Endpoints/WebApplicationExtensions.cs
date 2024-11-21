using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Snap.Financials.Endpoints.Endpoints.Contracts;

namespace Snap.Financials.Endpoints;

public static class WebApplicationExtensions
{
    public static WebApplication RegisterEndpoints(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var factory = scope.ServiceProvider.GetRequiredService<IEndpointFactory>();
        factory.CreateEndpoints(app);
        return app;
    }
}
