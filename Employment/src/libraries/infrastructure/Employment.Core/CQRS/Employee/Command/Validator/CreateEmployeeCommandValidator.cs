using FluentValidation;

namespace Employment.Core.CQRS.Employee.Command.Validator;

public class CreateEmployeeCommandValidator: AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.employee.DepartmentId).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.employee.CountryId).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.employee.StateId).NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.employee.CityId).NotEmpty().WithMessage("Id is required.");
    }
}
