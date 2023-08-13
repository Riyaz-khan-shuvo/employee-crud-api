using Employment.Core.CQRS.City.Query;
using FluentValidation;

namespace Employment.Core.CQRS.Country.Query.Validation;

public class GetCountoryQueryByIdValidator:AbstractValidator<GetCountryQueryById>
{
    public GetCountoryQueryByIdValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Required .");
    }
}
