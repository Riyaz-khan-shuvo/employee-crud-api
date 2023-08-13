using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using MediatR;

namespace Employment.Core.CQRS.Country.Query;
public record GetCountoryAllQuery():IRequest<QueryResult<IEnumerable<VMCountry>>>;
public class GetCountoryAllQueryHandeler : IRequestHandler<GetCountoryAllQuery, QueryResult<IEnumerable<VMCountry>>>
{
	private readonly ICountryRepository _countryRepository;
    public GetCountoryAllQueryHandeler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }
    public async Task<QueryResult<IEnumerable<VMCountry>>> Handle(GetCountoryAllQuery request, CancellationToken cancellationToken)
	{
        var result = await _countryRepository.GetAllAsync();
        ;
        return result switch
        {
            null => new QueryResult<IEnumerable<VMCountry>>(null,QueryResultTypeEnum.NotFound),
            _ => new QueryResult<IEnumerable<VMCountry>>(result,QueryResultTypeEnum.Success)
        };
	}
}
