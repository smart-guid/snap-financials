using Microsoft.AspNetCore.Builder;

namespace Snap.Financials.Endpoints.Endpoints;

public interface IEndpoint
{
    void MapEndpoints(WebApplication app);
}

