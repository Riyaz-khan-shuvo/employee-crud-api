using FluentValidation;

namespace Employment.Core.CQRS.Country.Query.Validation;

public class GetCountryQueryByIdVaildation: AbstractValidator<GetCountryQueryById>
{
    public GetCountryQueryByIdVaildation()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Required .");
    }
}
