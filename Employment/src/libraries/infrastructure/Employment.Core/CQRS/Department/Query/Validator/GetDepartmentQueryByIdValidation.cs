using FluentValidation;

namespace Employment.Core.CQRS.Department.Query.Validator;

public class GetDepartmentQueryByIdValidation: AbstractValidator<GetDepartmentQueryById>
{
    public GetDepartmentQueryByIdValidation()
    {
        RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is Requried.");
    }
}
