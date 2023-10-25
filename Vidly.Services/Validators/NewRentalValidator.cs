using FluentValidation;
using Vidly.Services.Dtos;

namespace Vidly.Services.Validators;

public class NewRentalValidator : AbstractValidator<NewRentalDto>
{
    public NewRentalValidator()
    {
        RuleFor(r => r.CustomerId).NotEmpty();
        RuleFor(r => r.MovieIds).NotEmpty();
    }
}