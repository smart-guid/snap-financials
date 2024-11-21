using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Snap.Financials.Endpoints.Endpoints;
using Snap.Financials.Endpoints.Endpoints.Contracts;
using System.Reflection;

namespace Snap.Financials.Endpoints;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IEndpointFactory, EndpointFactory>()
                .AddScoped<IEndpoint, CustomerEndpoints>()
                .AddScoped<IEndpoint, CompanyInfoEndpoints>()
                .AddScoped<IEndpoint, InvoiceEndpoints>();

        return services;
    }
}

