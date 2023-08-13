using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;
namespace Employment.Core.CQRS.Country.Command;
public record CreateCountryCommand(VMCountry vmCountry) : IRequest<CommandResult<VMCountry>>;
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CommandResult<VMCountry>>
{
	private readonly ICountryRepository _countryRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<CreateCountryCommand> _validator;
	public CreateCountryCommandHandler(IMapper mapper,ICountryRepository countryRepository, IValidator<CreateCountryCommand> validator)
	{
		_mapper = mapper;
		_countryRepository = countryRepository;
		_validator = validator;
	}
	public async Task<CommandResult<VMCountry>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
	{
		var vaildator= await _validator.ValidateAsync(request,cancellationToken);
		if (!vaildator.IsValid) throw new ValidationException(vaildator.Errors);
		var data= _mapper.Map<Model.Entities.Country>(request.vmCountry);
		var result = await _countryRepository.InsertAsync(data);
		;
		return result switch
		{
			null=>new CommandResult<VMCountry>(null,CommandResultTypeEnum.InvalidInput),
			_ => new CommandResult<VMCountry>(result,CommandResultTypeEnum.Success)
		};
	}
}
