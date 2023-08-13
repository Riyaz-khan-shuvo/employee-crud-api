using AutoMapper;

using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Employee.Command;

public record CreateEmployeeCommand(VMEmployee employee):IRequest<CommandResult<VMEmployee>>;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, CommandResult<VMEmployee>>
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IValidator<CreateEmployeeCommand> _validator;
	private readonly IMapper _mapper;
	public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper, IValidator<CreateEmployeeCommand> validator)
	{
		_employeeRepository = employeeRepository;
		_mapper = mapper;
		_validator = validator;
	}

	public async Task<CommandResult<VMEmployee>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
	{

		var validate = await _validator.ValidateAsync(request, cancellationToken);
		if (!validate.IsValid) throw new ValidationException(validate.Errors);







		var result = _mapper.Map<Model.Entities.Employee>(request.employee);

		var employee = await _employeeRepository.InsertAsync(result);
		;
		return employee switch
		{
			null => new CommandResult<VMEmployee>(null, CommandResultTypeEnum.NotFound),
			_ => new CommandResult<VMEmployee>(employee, CommandResultTypeEnum.Success)
		};
	}
}

