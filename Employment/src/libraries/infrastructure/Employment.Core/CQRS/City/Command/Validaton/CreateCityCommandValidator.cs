using FluentValidation;

namespace Employment.Core.CQRS.City.Command.Validaton;

public class CreateCityCommandValidator: AbstractValidator<CreateCityCommand>
{
    public CreateCityCommandValidator()
    {
        RuleFor(x=>x.city.CityName).NotEmpty().WithMessage("City Name is Required.");
    }
}
