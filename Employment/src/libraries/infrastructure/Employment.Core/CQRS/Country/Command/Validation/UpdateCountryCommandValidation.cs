using FluentValidation;
namespace Employment.Core.CQRS.Country.Command.Validation;
public class UpdateCountryCommandValidation: AbstractValidator<UpdateCountryCommand>
{
    public UpdateCountryCommandValidation()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Required.");
    }
}
