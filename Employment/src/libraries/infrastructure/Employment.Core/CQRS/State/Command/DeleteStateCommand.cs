using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.State.Command;

public record DeleteStateCommand (int Id):IRequest<CommandResult<VMState>>;

public class DeleteStateCommanddHandler : IRequestHandler<DeleteStateCommand, CommandResult<VMState>>
{
	private readonly ISateRepository _sateRepository;
	private readonly IValidator<DeleteStateCommand> _validator;
	
	public DeleteStateCommanddHandler(ISateRepository sateRepository, IValidator<DeleteStateCommand> validator)
	{
		_sateRepository = sateRepository;
		_validator = validator;
		
	}
	public async Task<CommandResult<VMState>> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
	{
		var vaildator = await _validator.ValidateAsync(request, cancellationToken);
		if (!vaildator.IsValid) throw new ValidationException(vaildator.Errors);
		
		var result = await _sateRepository.DeleteAsync(request.Id);
		;
		return result switch
		{
			null => new CommandResult<VMState>(null, CommandResultTypeEnum.NotFound),
			_ => new CommandResult<VMState>(result, CommandResultTypeEnum.Success)
		};
	}
}

