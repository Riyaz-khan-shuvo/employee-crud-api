using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using MediatR;

namespace Employment.Core.CQRS.State.Query;

public record GetStateAll():IRequest<QueryResult<IEnumerable< VMState>>>;

public class GetStateAllHandler : IRequestHandler<GetStateAll, QueryResult<IEnumerable<VMState>>>
{

	private readonly ISateRepository _sateRepository;
	public GetStateAllHandler(ISateRepository sateRepository)
	{
		_sateRepository = sateRepository;
	}
	public async Task<QueryResult<IEnumerable<VMState>>> Handle(GetStateAll request, CancellationToken cancellationToken)
	{
		var result = await _sateRepository.GetAllAsync(x=>x.Country);
		;
		return result switch
		{
			null => new QueryResult<IEnumerable<VMState>>(null,QueryResultTypeEnum.NotFound),
			_ =>new QueryResult<IEnumerable<VMState>>(result,QueryResultTypeEnum.Success)

		};
	}
}

