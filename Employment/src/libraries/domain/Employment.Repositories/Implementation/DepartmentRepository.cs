using AutoMapper;
using Employment.DataAccess.Contracts.CommonInterface.BaseInterface;
using Employment.DataAccess.DatabaseContext;
using Employment.Model.Entities;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;

namespace Employment.Repositories.Implementation;

public class DepartmentRepository : RepositoryBase<Department, VMDepartment, int>, IDepartmentRepository
{
	public DepartmentRepository(EmploymentDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
	{
	}
}
