using FluentValidation;

namespace Employment.Core.CQRS.Employee.Command.Validator;

public class UpdateEmployeeCommandValidator: AbstractValidator<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        RuleFor(x=>x.id).NotEmpty().WithMessage("Id is required.");
    }
}
