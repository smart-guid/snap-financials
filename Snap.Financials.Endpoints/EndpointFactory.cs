using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Snap.Financials.Endpoints.Endpoints.Contracts;

namespace Snap.Financials.Endpoints;

public class EndpointFactory : IEndpointFactory
{
    private readonly IEnumerable<IEndpoint> _endpoints;
    private readonly ILogger _logger;

    public EndpointFactory(IEnumerable<IEndpoint> endpoints, ILogger<EndpointFactory> logger)
    {
        _endpoints = endpoints;
        _logger = logger;
    }

    public void CreateEndpoints(WebApplication app)
    {
        _logger.LogInformation("Creating application endpoints");

        foreach (var endpoint in _endpoints)
        {
            _logger.LogInformation("Creating {name} endpoint", nameof(endpoint));
            endpoint.MapEndpoints(app);
        }
    }
}
