using AutoMapper;
using Employment.Core.CQRS.Country.Command;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;
namespace Employment.Core.CQRS.City.Command;
public record CreateCityCommand(VMCity city):IRequest<CommandResult<VMCity>>;
public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CommandResult<VMCity>>
{
	private readonly ICityRepository  _cityRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<CreateCityCommand> _validator;
	public CreateCityCommandHandler(IMapper mapper, ICityRepository cityRepository, IValidator<CreateCityCommand> validator)
	{
		_mapper = mapper;
		_cityRepository = cityRepository;
		_validator = validator;
	}
	public async Task<CommandResult<VMCity>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
	{
		var vaildator = await _validator.ValidateAsync(request, cancellationToken);
		if (!vaildator.IsValid) throw new ValidationException(vaildator.Errors);
		var data = _mapper.Map<Model.Entities.City>(request.city);
		var result = await _cityRepository.InsertAsync(data);
		;
		return result switch
		{
			null => new CommandResult<VMCity>(null, CommandResultTypeEnum.InvalidInput),
			_ => new CommandResult<VMCity>(result, CommandResultTypeEnum.Success)
		};
	}
}

