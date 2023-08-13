using FluentValidation;

namespace Employment.Core.CQRS.City.Command.Validaton;

public class DeleteCityCommandValidation:AbstractValidator<DeleteCityCommand>
{
    public DeleteCityCommandValidation()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Required.");
    }
}
