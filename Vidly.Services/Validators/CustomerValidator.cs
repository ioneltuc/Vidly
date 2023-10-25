using FluentValidation;
using Vidly.Services.Dtos;

namespace Vidly.Services.Validators;

public class CustomerValidator : AbstractValidator<CustomerDto>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(255);
        RuleFor(c => c.MembershipTypeId).NotNull();
        RuleFor(c => c.MembershipType).SetValidator(new MembershipTypeValidator());
    }
}