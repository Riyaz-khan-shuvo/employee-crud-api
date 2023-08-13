using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.City.Query;

public record GetCityQueryById(int Id):IRequest<QueryResult<VMCity>>;
public class GetCityQueryByIdHandler : IRequestHandler<GetCityQueryById, QueryResult<VMCity>>
{
	private readonly ICityRepository _cityRepository;
	private readonly IValidator<GetCityQueryById> _validator;
    public GetCityQueryByIdHandler(ICityRepository cityRepository, IValidator<GetCityQueryById> validator)
    {
		_cityRepository = cityRepository;
		_validator = validator;
    }
    public async Task<QueryResult<VMCity>> Handle(GetCityQueryById request, CancellationToken cancellationToken)
	{

		var vaildator= await _validator.ValidateAsync(request, cancellationToken);
		if (!vaildator.IsValid) throw new ValidationException(vaildator.Errors);
		var result= await _cityRepository.GetByIdAsync(request.Id);
		;
		return result switch
		{
			null => new QueryResult<VMCity>(null, QueryResultTypeEnum.NotFound),
			_ => new QueryResult<VMCity>(result, QueryResultTypeEnum.Success)
		};

	}
}

