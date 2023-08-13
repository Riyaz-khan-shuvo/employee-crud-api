using FluentValidation;

namespace Employment.Core.CQRS.Department.Command.Validator;

public class UpdateDepartmentCommandValidatore: AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentCommandValidatore()
    {
        RuleFor(x=>x.department.Id).NotEmpty().WithMessage("id is reqired");
    }
}
