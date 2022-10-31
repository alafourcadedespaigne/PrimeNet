using FluentValidation;

namespace PrimeNet.Application.Features.Companies.Commands.UpdateCompany;

public class UpdateCompanyCommandValidator: AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotNull().WithMessage("{Name} not allow null values");
        RuleFor(p => p.Url)
            .NotNull().WithMessage("{Url} not allow null values");

    }
}