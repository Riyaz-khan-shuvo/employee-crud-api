using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;

namespace Employment.Core.CQRS.City.Query;

public record GetCityAllQuery():IRequest<QueryResult<IEnumerable< VMCity>>>;
public class GetCityAllQueryHandaler : IRequestHandler<GetCityAllQuery, QueryResult<IEnumerable<VMCity>>>
{
	private readonly ICityRepository _cityRepository;
    public GetCityAllQueryHandaler(ICityRepository cityRepository)
    {
		_cityRepository = cityRepository;
		
    }
    public async Task<QueryResult<IEnumerable<VMCity>>> Handle(GetCityAllQuery request, CancellationToken cancellationToken)
	{
		var result = await _cityRepository.GetAllAsync(x=>x.States);
		

		;
		return result switch
		{
			null => new QueryResult<IEnumerable<VMCity>>(null, QueryResultTypeEnum.NotFound),
			_ => new QueryResult<IEnumerable<VMCity>>(result, QueryResultTypeEnum.Success)
		};
		
	}
}

