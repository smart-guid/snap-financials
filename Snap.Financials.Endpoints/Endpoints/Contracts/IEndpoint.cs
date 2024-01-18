using Microsoft.AspNetCore.Builder;

namespace Snap.Financials.Endpoints.Endpoints.Contracts;

public interface IEndpoint
{
    void MapEndpoints(WebApplication app);
}

