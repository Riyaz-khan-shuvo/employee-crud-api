using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.Country.Command;

public record UpdateCountryCommand(int Id,VMCountry country):IRequest<CommandResult<VMCountry>>;

public class UpdateCountryCommandHandeler : IRequestHandler<UpdateCountryCommand, CommandResult<VMCountry>>
{
	private readonly ICountryRepository _countryRepository;
	private readonly IMapper _mapper;
	private readonly IValidator<UpdateCountryCommand> _validator;

	public UpdateCountryCommandHandeler(IValidator<UpdateCountryCommand> validator,IMapper mapper,ICountryRepository countryRepository)
	{
		_validator = validator;
		_mapper = mapper;
		_countryRepository = countryRepository;
	}

	public async Task<CommandResult<VMCountry>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
	{
		var validator= await _validator.ValidateAsync(request, cancellationToken);
		if (!validator.IsValid) throw new ValidationException(validator.Errors);
		var data = _mapper.Map<Model.Entities.Country>(request.country);
		var result = await _countryRepository.UpdateAsync( request.Id,data);
		;
		return request switch
		{
			null=>new CommandResult<VMCountry>(null,CommandResultTypeEnum.InvalidInput),
			_ => new CommandResult<VMCountry>(result,CommandResultTypeEnum.Success)
		};
	}
}


