using FluentValidation;

namespace Employment.Core.CQRS.Country.Command.Validation;

public class DeleteCountryCommandHandeler: AbstractValidator<DeleteCountryCommand>
{
    public DeleteCountryCommandHandeler()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Required.");
    }
}
