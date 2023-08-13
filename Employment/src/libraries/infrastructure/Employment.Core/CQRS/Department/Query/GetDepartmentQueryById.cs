using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Models;
using FluentValidation;
using MediatR;
namespace Employment.Core.CQRS.Department.Query;
public record GetDepartmentQueryById(int Id):IRequest<QueryResult<VMDepartment>>;
public class GetDepartmentQueryByIdHandler : IRequestHandler<GetDepartmentQueryById, QueryResult<VMDepartment>>
{
	private readonly IDepartmentRepository _departmentRepository;
    private readonly IValidator<GetDepartmentQueryById> _validator;
    public GetDepartmentQueryByIdHandler(IDepartmentRepository departmentRepository, IValidator<GetDepartmentQueryById> validator)
    {
        _departmentRepository = departmentRepository;
        _validator = validator;
    }
    public async Task<QueryResult<VMDepartment>> Handle(GetDepartmentQueryById request, CancellationToken cancellationToken)
	{
		var validator= await _validator.ValidateAsync(request, cancellationToken);
        if (!validator.IsValid) throw new ValidationException(validator.Errors);
        var result = await _departmentRepository.GetByIdAsync(request.Id);
        ;
        return result switch
        {
            null=>new QueryResult<VMDepartment>(null,QueryResultTypeEnum.NotFound),
            _ =>new QueryResult<VMDepartment>(result,QueryResultTypeEnum.Success)
        };
	}
}


