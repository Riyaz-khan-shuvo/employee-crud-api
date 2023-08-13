using FluentValidation;

namespace Employment.Core.CQRS.Department.Command.Validator;

public class CreateDepartmentValidator: AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentValidator()
    {
        RuleFor(x=>x.department.DepartmentName).NotEmpty().WithMessage("Department Name is Required.");
    }
}
