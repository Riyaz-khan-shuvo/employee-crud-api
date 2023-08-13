using AutoMapper;
using Employment.Core.CQRS.State.Query;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.State.Command;

public record CrateStateCommand(VMState state):IRequest<CommandResult<VMState>>;
public class CrateStateCommandHandler : IRequestHandler<CrateStateCommand, CommandResult<VMState>>
{
	private readonly ISateRepository _sateRepository;
	private readonly IValidator<CrateStateCommand> _validator;
	private readonly IMapper _mapper;
	public CrateStateCommandHandler(ISateRepository sateRepository, IValidator<CrateStateCommand> validator,IMapper mapper)
	{
		_sateRepository = sateRepository;
		_validator = validator;
		_mapper = mapper;
	}
	public async Task<CommandResult<VMState>> Handle(CrateStateCommand request, CancellationToken cancellationToken)
	{
		 var vaildator= await _validator.ValidateAsync(request, cancellationToken);
		if (!vaildator.IsValid) throw new ValidationException(vaildator.Errors);
		var data = _mapper.Map<Model.Entities.State>(request.state);
		var result = await _sateRepository.InsertAsync(data);
		;
		return result switch
		{
			null => new CommandResult<VMState>(null, CommandResultTypeEnum.InvalidInput),
			_ =>new CommandResult<VMState>(result, CommandResultTypeEnum.Success)
		};
	}
}

