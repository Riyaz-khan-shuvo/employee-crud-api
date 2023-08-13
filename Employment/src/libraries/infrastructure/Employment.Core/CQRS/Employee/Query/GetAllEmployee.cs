using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using MediatR;

namespace Employment.Core.CQRS.Employee.Query;


	public record GetAllEmployeeQuery():IRequest<QueryResult<IEnumerable<VMEmployee>>>;
	public class GetAllEmployeeQueryHandeler : IRequestHandler<GetAllEmployeeQuery, QueryResult<IEnumerable<VMEmployee>>>
	{
		private readonly IEmployeeRepository _employeeRepository;
		
        public GetAllEmployeeQueryHandeler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<QueryResult<IEnumerable<VMEmployee>>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
		{
			var employee = await _employeeRepository.GetAllAsync(x=>x.Country,x=>x.City,c=>c.State,s=>s.Department);

			
			return employee switch
			{
				null => new  QueryResult<IEnumerable<VMEmployee>>(null, QueryResultTypeEnum.NotFound),
				_ => new QueryResult<IEnumerable<VMEmployee>>(employee, QueryResultTypeEnum.Success)
			};
		}
	}


