using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using MediatR;

namespace Employment.Core.CQRS.Department.Query;

public record GetDepartmentAllQuery():IRequest<QueryResult<IEnumerable<VMDepartment>>>;

public class GetDepartmentAllHandler : IRequestHandler<GetDepartmentAllQuery, QueryResult<IEnumerable<VMDepartment>>>
{
	private readonly IDepartmentRepository _departmentRepository;
	public GetDepartmentAllHandler(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;
	public async Task<QueryResult<IEnumerable<VMDepartment>>> Handle(GetDepartmentAllQuery request, CancellationToken cancellationToken)
	{
		var result = await _departmentRepository.GetAllAsync();
		;
		return result switch
		{
			null => new QueryResult<IEnumerable<VMDepartment>>(null, QueryResultTypeEnum.NotFound),
			_ => new QueryResult<IEnumerable<VMDepartment>>(result, QueryResultTypeEnum.Success),
		} ;
	}
}

