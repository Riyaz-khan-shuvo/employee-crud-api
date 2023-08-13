using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;
namespace Employment.Core.CQRS.Country.Command;
public record DeleteCountryCommand(int Id):IRequest<CommandResult<VMCountry>>;
public class DeleteCountryCommandHandeler : IRequestHandler<DeleteCountryCommand, CommandResult<VMCountry>>
{
	private readonly ICountryRepository _countryRepository;
	private readonly IValidator<DeleteCountryCommand> _validator;

	public DeleteCountryCommandHandeler(IValidator<DeleteCountryCommand> validator,ICountryRepository countryRepository)
	{
		_validator = validator;
		_countryRepository = countryRepository;
	}

	public async Task<CommandResult<VMCountry>> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
	{
		var vaildator= await _validator.ValidateAsync(request,cancellationToken);
		if (!vaildator.IsValid) throw new ValidationException(vaildator.Errors);
		var result = await _countryRepository.DeleteAsync(request.Id);
		;
		return result switch
		{
			null=>new CommandResult<VMCountry>(null,CommandResultTypeEnum.NotFound),
			_ => new CommandResult<VMCountry>(result,CommandResultTypeEnum.Success)
		};
	}
}

