using Microsoft.AspNetCore.Builder;

namespace Snap.Financials.Endpoints.Endpoints.Contracts;

public interface IEndpointFactory
{
    void CreateEndpoints(WebApplication app);
}
