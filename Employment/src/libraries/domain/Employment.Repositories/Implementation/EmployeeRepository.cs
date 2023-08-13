using AutoMapper;
using Employment.DataAccess.Contracts.CommonInterface.BaseInterface;
using Employment.DataAccess.DatabaseContext;
using Employment.Model.Entities;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;

namespace Employment.Repositories.Implementation;

public class EmployeeRepository : RepositoryBase<Employee, VMEmployee, int>, IEmployeeRepository
{
	public EmployeeRepository(EmploymentDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
	{

	}
}
