using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Department.Command;

public record DeleteDepartmentCommand(int Id):IRequest<CommandResult<VMDepartment>>;

public class DeleteDepartmentCommandHandeler : IRequestHandler<DeleteDepartmentCommand, CommandResult<VMDepartment>>
{
	private readonly IDepartmentRepository _departmentRepository;
	private readonly IValidator<DeleteDepartmentCommand> _validator;

	public DeleteDepartmentCommandHandeler(IDepartmentRepository departmentRepository, IValidator<DeleteDepartmentCommand> validator)
	{
		_departmentRepository = departmentRepository;
		_validator = validator;
	}

	public async Task<CommandResult<VMDepartment>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
	{
		var vaildator= await _validator.ValidateAsync(request,cancellationToken);
		if (!vaildator.IsValid) throw new ValidationException(vaildator.Errors);
		var result = await _departmentRepository.DeleteAsync(request.Id);
		;
		return result switch
		{
			null => new CommandResult<VMDepartment>(null, CommandResultTypeEnum.NotFound),
			_ => new CommandResult<VMDepartment>(result, CommandResultTypeEnum.Success)

		} ;

	}
}


