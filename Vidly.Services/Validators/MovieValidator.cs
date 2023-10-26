using FluentValidation;
using Vidly.Services.Dtos;

namespace Vidly.Services.Validators;

public class MovieValidator : AbstractValidator<MovieDto>
{
    public MovieValidator()
    {
        RuleFor(m => m.Name).NotEmpty().MaximumLength(64);
        RuleFor(m => m.Genre).NotNull().IsInEnum();
        RuleFor(m => m.ReleasedDate).NotNull();
        RuleFor(m => m.NumberInStock).GreaterThan(0).LessThanOrEqualTo(20);
    }
}