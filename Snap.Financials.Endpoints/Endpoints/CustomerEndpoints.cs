using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Snap.Financials.Endpoints.Endpoints.Contracts;
using Snap.Financials.Endpoints.Validators;
using Snap.Financials.Models;
using Snap.Financials.Repositories;

namespace Snap.Financials.Endpoints.Endpoints;

public class CustomerEndpoints : IEndpoint
{
    private readonly ICustomerRepository _repository;
    private readonly ILogger _logger;

    public CustomerEndpoints(ICustomerRepository repository, ILogger<CustomerEndpoints> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public void MapEndpoints(WebApplication app)
    {
        var group = app.MapGroup("/api/customers")
          .WithTags("customers")
          .WithOpenApi();

        group.MapGet("/", GetCustomersAsync)
            .Produces<IList<CustomerModel>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        group.MapGet("/{id:guid}", GetCustomerByIdAsync)
            .AddEndpointFilter<ValidationFilter<Guid>>()
            .Produces<CustomerModel>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem();

        group.MapPost("/", CreateCustomer)
            .AddEndpointFilter<ValidationFilter<CustomerModel>>()
            .Produces<CustomerModel>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem();

        group.MapPut("/", UpdateCustomer)
            .AddEndpointFilter<ValidationFilter<Guid>>()
            .AddEndpointFilter<ValidationFilter<CustomerModel>>()
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem();
    }


    public async Task<IResult> GetCustomersAsync(CancellationToken cancellationToken)
    {
        try
        {
            return Results.Ok(await _repository.GetCustomersAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(GetCustomersAsync));
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IResult> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var customer = await _repository.GetCustomerByIdAsync(id, cancellationToken);
            if (customer == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(GetCustomersAsync));
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IResult> CreateCustomer([FromBody] CustomerModel model, CancellationToken cancellationToken)
    {
        try
        {
            return Results.Ok(await _repository.CreateCustomerAsync(model, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(GetCustomersAsync));
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IResult> UpdateCustomer([FromBody] CustomerModel model, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.UpdateCustomerAsync(model, cancellationToken);

            return Results.NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(GetCustomersAsync));
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

}

