using AutoMapper;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.City.Command;
public record DeleteCityCommand(int Id):IRequest<CommandResult<VMCity>>;

public class DeleteCityCommandHandeler : IRequestHandler<DeleteCityCommand, CommandResult<VMCity>>
{

	private readonly ICityRepository _cityRepository;
	private readonly IValidator<DeleteCityCommand> _validator;
    public DeleteCityCommandHandeler(ICityRepository cityRepository,IValidator<DeleteCityCommand> validator)
    {
		_cityRepository = cityRepository;
		_validator = validator;
        
    }

    public async Task<CommandResult<VMCity>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
	{
		var validator= await _validator.ValidateAsync(request, cancellationToken);
		if (!validator.IsValid) throw new ValidationException(validator.Errors);
		var result=await _cityRepository.DeleteAsync(request.Id);
		;
		return result switch
		{
			null=>new CommandResult<VMCity>(null,CommandResultTypeEnum.NotFound),
			_ => new CommandResult<VMCity>(result,CommandResultTypeEnum.Success)
		};
	}
}

