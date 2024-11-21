using FluentValidation;
using Snap.Financials.Endpoints.Requests;
using Snap.Financials.Models;

namespace Snap.Financials.Endpoints.Validators;

public class InvoiceValidator : AbstractValidator<InvoiceModel>
{
    public InvoiceValidator()
    {
        this.RuleFor(r => r.Id).NotEqual(Guid.Empty).WithMessage("An id was not supplied.");            
        //this.RuleFor(r => r.Stars).InclusiveBetween(1, 5).WithMessage("A star rating must be between 1 and 5.");
    }
}


public class CreateInvoiceValidator: AbstractValidator<CreateInvoiceRequest>
{
    public CreateInvoiceValidator()
    {
        this.RuleFor(r => r.CustomerId).NotEqual(Guid.Empty).WithMessage("An id was not supplied.");
        //this.RuleFor(r => r.Stars).InclusiveBetween(1, 5).WithMessage("A star rating must be between 1 and 5.");
    }
}
