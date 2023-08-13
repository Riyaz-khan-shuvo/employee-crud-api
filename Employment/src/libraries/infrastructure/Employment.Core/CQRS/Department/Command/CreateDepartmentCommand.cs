using AutoMapper;
using Employment.Model.Entities;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Department.Command;
public record CreateDepartmentCommand(VMDepartment department):IRequest<CommandResult<VMDepartment>>;
public class CreateDepartmentCommandHandeler : IRequestHandler<CreateDepartmentCommand, CommandResult<VMDepartment>>
{
	private readonly IDepartmentRepository _departmentRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<CreateDepartmentCommand> _validator;
	public CreateDepartmentCommandHandeler(IMapper mapper,IDepartmentRepository departmentRepository, IValidator<CreateDepartmentCommand> validator)
	{
		_mapper = mapper;
		_departmentRepository = departmentRepository;	
		_validator = validator;
	}
	public async Task<CommandResult<VMDepartment>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
	{
		var validator= await _validator.ValidateAsync(request, cancellationToken);
		if (!validator.IsValid) throw new ValidationException(validator.Errors);
		var data = _mapper.Map<Model.Entities.Department>(request.department);
		var result = await _departmentRepository.InsertAsync(data);
		;
		return result switch
		{
			null => new CommandResult<VMDepartment>(null, CommandResultTypeEnum.InvalidInput),
			_ => new CommandResult<VMDepartment>(result, CommandResultTypeEnum.Success)
		} ;
	}
}



