using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.State.Command;

public record UpdateStateCommand(int Id,VMState state) : IRequest<CommandResult<VMState>>;

public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, CommandResult<VMState>>
{
	private readonly ISateRepository _sateRepository;
	private readonly IValidator<UpdateStateCommand> _validator;
	private readonly IMapper _mapper;
	public UpdateStateCommandHandler(ISateRepository sateRepository, IValidator<UpdateStateCommand> validator, IMapper mapper)
	{
		_sateRepository = sateRepository;
		_validator = validator;
		_mapper = mapper;
	}
	public async Task<CommandResult<VMState>> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
	{
		var vaildator = await _validator.ValidateAsync(request, cancellationToken);
		if (!vaildator.IsValid) throw new ValidationException(vaildator.Errors);
		var data = _mapper.Map<Model.Entities.State>(request.state);
		var result = await _sateRepository.UpdateAsync(request.Id,data);
		;
		return result switch
		{
			null => new CommandResult<VMState>(null, CommandResultTypeEnum.InvalidInput),
			_ => new CommandResult<VMState>(result, CommandResultTypeEnum.Success)
		};
	}
}

