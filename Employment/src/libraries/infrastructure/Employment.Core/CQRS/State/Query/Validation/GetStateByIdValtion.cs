using FluentValidation;

namespace Employment.Core.CQRS.State.Query.Validation;

public class GetStateByIdValtion:AbstractValidator<GetStateById>
{
    public GetStateByIdValtion()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Requrid .");
    }
}
