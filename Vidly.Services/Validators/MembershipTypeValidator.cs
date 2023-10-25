using FluentValidation;
using Vidly.Services.Dtos;

namespace Vidly.Services.Validators;

public class MembershipTypeValidator : AbstractValidator<MembershipTypeDto>
{
    public MembershipTypeValidator()
    {
        RuleFor(mt => mt.Name).NotEmpty();
    }
}