using Employment.Repositories.Implementation;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Employee.Command;

public record DeleteEmployeeCommand(int id):IRequest<CommandResult<VMEmployee>>;

public class DeleteEmployeeCommandHandeler : IRequestHandler<DeleteEmployeeCommand, CommandResult<VMEmployee>>
{

	private readonly IEmployeeRepository _employeeRepository;
	private readonly IValidator<DeleteEmployeeCommand> _validator;
    public DeleteEmployeeCommandHandeler(IValidator<DeleteEmployeeCommand> validator,IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
		_validator = validator;
    }
    public async Task<CommandResult<VMEmployee>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
	{
		var validate= await _validator.ValidateAsync(request, cancellationToken);
		if (!validate.IsValid) throw new ValidationException(validate.Errors);
		var result = await _employeeRepository.DeleteAsync(request.id);
		;
		return request switch
		{
			null => new CommandResult<VMEmployee>(null, CommandResultTypeEnum.NotFound),
			_ => new CommandResult<VMEmployee>(result, CommandResultTypeEnum.Success)

		} ;

	}
}


