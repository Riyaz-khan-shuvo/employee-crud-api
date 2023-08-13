using Employment.Service.Models.ViewModel;
using FluentValidation;

namespace Employment.Core.CQRS.City.Command.Validaton;
public class UpdateCityCommandValidation: AbstractValidator<UpdateCityCommand>
{
    public UpdateCityCommandValidation()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Required .");
    }
}
