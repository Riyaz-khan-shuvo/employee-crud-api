using FluentValidation;

namespace Employment.Core.CQRS.State.Command.Validation;

public class CreateStateCommandValidation:AbstractValidator<CrateStateCommand>
{
    public CreateStateCommandValidation()
    {
        RuleFor(x=>x.state.StateName).NotEmpty().WithMessage("State Name is Requird .");
    }
}
