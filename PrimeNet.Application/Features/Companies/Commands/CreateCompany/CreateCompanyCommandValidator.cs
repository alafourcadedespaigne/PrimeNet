using FluentValidation;

namespace PrimeNet.Application.Features.Companies.Commands.CreateCompany;

public class CreateCompanyCommandValidator: AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} cannot be blank")
            .NotNull()
            .MaximumLength(50).WithMessage("{Name} can not exceed 50 characters");
        RuleFor(p => p.Url)
            .NotEmpty().WithMessage("The {Url} can not be blank.");
    }
}