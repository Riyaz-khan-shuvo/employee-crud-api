using FluentValidation;

namespace Employment.Core.CQRS.Employee.Command.Validator;

public class DeleteEmployeeCommandValidator: AbstractValidator<DeleteEmployeeCommand>
{
    public DeleteEmployeeCommandValidator()
    {
        RuleFor(x=>x.id).NotEmpty().WithMessage("Id is required.");
    }
}
