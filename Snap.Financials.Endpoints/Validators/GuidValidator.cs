using FluentValidation;

namespace Snap.Financials.Endpoints.Validators;

public class GenericIdentityValidator : AbstractValidator<Guid>
{
    public GenericIdentityValidator()
    {
         this.RuleFor(r => r).NotEqual(Guid.Empty).WithMessage("A valid Id was not supplied.");
    }
}
