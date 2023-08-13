using Employment.DataAccess.Contracts.CommonInterface;
using Employment.Model.Entities;
using Employment.Repositories.Implementation;
using Employment.Service.Models.ViewModel;

namespace Employment.Repositories.Interface;

public interface IEmployeeRepository:IRepository<Employee, VMEmployee,int>
{
}
