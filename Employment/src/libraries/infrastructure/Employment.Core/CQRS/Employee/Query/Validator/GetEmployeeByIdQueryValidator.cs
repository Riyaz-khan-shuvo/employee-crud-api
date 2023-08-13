using FluentValidation;

namespace Employment.Core.CQRS.Employee.Query.Validator
{
	public class GetEmployeeByIdQueryValidator: AbstractValidator<GetEmployeeByIdQuery>
	{
        public GetEmployeeByIdQueryValidator()
        {
            RuleFor(x=>x.Id).NotEmpty().WithMessage("Id is required.");
        }
    }
}
