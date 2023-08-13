using FluentValidation;

namespace Employment.Core.CQRS.Department.Command.Validator;

public class DeleteDepartmentCommandValidator: AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteDepartmentCommandValidator()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Required.");
    }
}
