using FluentValidation;

namespace Employment.Core.CQRS.State.Command.Validation;

public class UpdateStateValidation:AbstractValidator<UpdateStateCommand>
{
    public UpdateStateValidation()
    {
		RuleFor(x => x.Id).NotEmpty().WithMessage("Id is Reqired .");
	}
}
