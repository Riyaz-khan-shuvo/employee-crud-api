using AutoMapper;
using Employment.DataAccess.Contracts.CommonInterface.BaseInterface;
using Employment.DataAccess.DatabaseContext;
using Employment.Model.Entities;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;

namespace Employment.Repositories.Implementation;

public class SateRepository : RepositoryBase<State, VMState, int>,ISateRepository
{
	public SateRepository(EmploymentDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
	{

	}
}
