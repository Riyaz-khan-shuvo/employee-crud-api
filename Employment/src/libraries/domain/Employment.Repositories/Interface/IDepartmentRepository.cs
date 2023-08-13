using Employment.DataAccess.Contracts.CommonInterface;
using Employment.Model.Entities;
using Employment.Service.Models.ViewModel;

namespace Employment.Repositories.Interface;

public interface IDepartmentRepository:IRepository<Department,VMDepartment,int>
{
}
