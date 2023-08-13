using FluentValidation;

namespace Employment.Core.CQRS.City.Query.Validation;

public class GetCityQueryByIdValidation:AbstractValidator<GetCityQueryById>
{
    public GetCityQueryByIdValidation()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Required .");
    }
}
