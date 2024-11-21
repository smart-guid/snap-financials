using FluentValidation;
using Snap.Financials.Models;

namespace Snap.Financials.Endpoints.Validators;

public class CustomerValidator : AbstractValidator<CustomerModel>
{
    public CustomerValidator()
    {
        this.RuleFor(r => r.Id).NotEqual(Guid.Empty).WithMessage("An id was not supplied.");
        // this.RuleFor(r => r.MovieId).NotEqual(Guid.Empty).WithMessage("A movie id was not supplied to create the review.");
        //this.RuleFor(r => r.Stars).InclusiveBetween(1, 5).WithMessage("A star rating must be between 1 and 5.");
    }
}
