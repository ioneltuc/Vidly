using FluentValidation;
using Vidly.Services.Dtos;

namespace Vidly.Services.Validators;

public class CustomerValidator : AbstractValidator<CustomerDto>
{
    public CustomerValidator()
    {
        RuleFor(c => c).Must(Be18IfMember).WithMessage("Customer should be at least 18 years old.");
        RuleFor(c => c.Name).NotEmpty().MaximumLength(255);
        RuleFor(c => c.MembershipTypeId).NotNull();
        RuleFor(c => c.MembershipType).SetValidator(new MembershipTypeValidator());
    }

    protected bool Be18IfMember(CustomerDto customer)
    {
        if (customer.MembershipTypeId == MembershipTypeDto.Unknown ||
            customer.MembershipTypeId == MembershipTypeDto.PayAsYouGo)
            return true;

        if (customer.Birthday == null)
            return false;

        var age = DateTime.Today.Year - customer.Birthday.Value.Year;
        if (customer.Birthday.Value.Date > DateTime.Today.AddYears(-age))
            age--;

        return age >= 18;
    }
}