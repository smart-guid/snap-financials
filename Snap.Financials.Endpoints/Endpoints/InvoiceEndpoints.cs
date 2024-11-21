using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Snap.Financials.Endpoints.Endpoints.Contracts;
using Snap.Financials.Endpoints.Requests;
using Snap.Financials.Endpoints.Validators;
using Snap.Financials.Models;
using Snap.Financials.Repositories;

namespace Snap.Financials.Endpoints.Endpoints;

public class InvoiceEndpoints : IEndpoint
{
    private readonly IInvoiceRepository _repository;
    private readonly ILogger _logger;

    public InvoiceEndpoints(IInvoiceRepository repository, ILogger<InvoiceEndpoints> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public void MapEndpoints(WebApplication app)
    {
        var group = app.MapGroup("/api/invoices")
         .WithTags("Invoices")
         .WithOpenApi();

        group.MapGet("/", GetInvoicesAsync)
            .Produces<IList<InvoiceModel>>()
            .ProducesProblem(StatusCodes.Status500InternalServerError);

        group.MapGet("/{id:guid}", GetInvoiceByIdAsync)
            .AddEndpointFilter<ValidationFilter<Guid>>()
            .Produces<InvoiceModel>()
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem();

        group.MapPost("/", CreateInvoiceAsync)
            .AddEndpointFilter<ValidationFilter<CreateInvoiceRequest>>()
            .Produces<InvoiceModel>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem();

        group.MapPut("/", UpdateInvoiceAsync)
            .AddEndpointFilter<ValidationFilter<Guid>>()
            .AddEndpointFilter<ValidationFilter<InvoiceModel>>()
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .ProducesValidationProblem();
    }

    public async Task<IResult> GetInvoicesAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("GetInvoicesAsync");

            return Results.Ok(await _repository.GetInvoicesAsync(cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(GetInvoicesAsync));
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IResult> GetInvoiceByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("GetInvoiceByIdAsync id={id}", id);

            var customer = await _repository.GetInvoiceByIdAsync(id, cancellationToken);
            if (customer == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(customer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(GetInvoiceByIdAsync));
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IResult> CreateInvoiceAsync([FromBody] CreateInvoiceRequest request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("CreateInvoiceAsync");

            return Results.Ok(await _repository.CreateInvoiceAsync(model, cancellationToken));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(CreateInvoiceAsync));
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }

    public async Task<IResult> UpdateInvoiceAsync([FromBody] InvoiceModel model, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("CreateInvoiceAsync");

            await _repository.UpdateInvoiceAsync(model, cancellationToken);

            return Results.NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, nameof(UpdateInvoiceAsync));
            return Results.Problem(ex.StackTrace, ex.Message, StatusCodes.Status500InternalServerError);
        }
    }
}
