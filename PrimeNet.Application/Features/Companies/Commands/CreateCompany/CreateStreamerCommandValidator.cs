using FluentValidation;

namespace PrimeNet.Application.Features.Streamers.Commands.CreateStreamer;

public class CreateStreamerCommandValidator: AbstractValidator<CreateStreamerCommand>
{
    public CreateStreamerCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} cannot be blank")
            .NotNull()
            .MaximumLength(50).WithMessage("{Name} can not exceed 50 characters");
        RuleFor(p => p.Url)
            .NotEmpty().WithMessage("The {Url} can not be blank.");
    }
}