using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Department.Command;

public record UpdateDepartmentCommand(int Id,VMDepartment department):IRequest<CommandResult<VMDepartment>>;
public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, CommandResult<VMDepartment>>
{
	private readonly IDepartmentRepository _departmentRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<UpdateDepartmentCommand> _validator;

	public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository,IValidator<UpdateDepartmentCommand> validator,IMapper mapper)
	{
		_departmentRepository = departmentRepository;
		_mapper = mapper;
		_validator = validator;
	}

	public async Task<CommandResult<VMDepartment>> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
	{
		var vaildation = await _validator.ValidateAsync(request, cancellationToken);
		if (!vaildation.IsValid) throw new ValidationException(vaildation.Errors);
		var data =  _mapper.Map<Model.Entities.Department>(request.department);

		var result= await _departmentRepository.UpdateAsync(request.department.Id, data);
		;
		return result switch
		{
			null=>new CommandResult<VMDepartment>(null,CommandResultTypeEnum.UnprocessableEntity),
			_ =>new CommandResult<VMDepartment>(result,CommandResultTypeEnum.Success)

		};
	}
}

