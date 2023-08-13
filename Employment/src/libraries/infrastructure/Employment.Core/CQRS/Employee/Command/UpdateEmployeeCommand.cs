using AutoMapper;
using Employment.Model.Entities;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Employee.Command;

public record UpdateEmployeeCommand(int id, VMEmployee employee):IRequest<CommandResult<VMEmployee>>;

public class UpdateEmployeeCommandHandeler : IRequestHandler<UpdateEmployeeCommand, CommandResult<VMEmployee>>
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<UpdateEmployeeCommand> _validator;
	public UpdateEmployeeCommandHandeler(IEmployeeRepository employeeRepository,IMapper mapper,IValidator<UpdateEmployeeCommand> validator)
	{
		_employeeRepository = employeeRepository;
		_mapper = mapper;
		_validator = validator;
	}

	public async Task<CommandResult<VMEmployee>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		var validate= await _validator.ValidateAsync(request, cancellationToken);
		if (!validate.IsValid) throw new ValidationException(validate.Errors);
		var data= _mapper.Map<Model.Entities.Employee>(request.employee);
		 var result=  await _employeeRepository.UpdateAsync(request.id, data);
		;
		return result switch { 
		null => new CommandResult<VMEmployee>(null,CommandResultTypeEnum.UnprocessableEntity),
		_ => new CommandResult<VMEmployee>(result,CommandResultTypeEnum.Success)
		};

	}
}
