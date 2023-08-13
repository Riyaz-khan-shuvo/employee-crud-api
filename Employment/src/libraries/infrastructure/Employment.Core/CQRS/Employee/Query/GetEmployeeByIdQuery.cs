using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;

namespace Employment.Core.CQRS.Employee.Query;

public class GetEmployeeByIdQuery:IRequest<QueryResult<VMEmployee>>
{
    [JsonConstructor]
    public GetEmployeeByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }

	public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, QueryResult<VMEmployee>>
	{
		private readonly IEmployeeRepository _employeeRepository;
        private readonly IValidator<GetEmployeeByIdQuery> _validator;
        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IValidator<GetEmployeeByIdQuery> validator)
        {
			_employeeRepository = employeeRepository;
            _validator = validator;
        }


        public async Task<QueryResult<VMEmployee>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
		{

			var validate = await _validator.ValidateAsync(request, cancellationToken);
			if (!validate.IsValid) throw new ValidationException(validate.Errors);

			var employee = await _employeeRepository.GetByIdAsync(request.Id);
			;
			return employee switch
			{
				null => new QueryResult<VMEmployee>(null, QueryResultTypeEnum.NotFound),
				_ => new QueryResult<VMEmployee>(employee, QueryResultTypeEnum.Success)
			};
		}
	}
}
