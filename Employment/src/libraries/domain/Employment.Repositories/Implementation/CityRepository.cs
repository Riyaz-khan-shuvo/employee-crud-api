using AutoMapper;
using Employment.DataAccess.Contracts.CommonInterface.BaseInterface;
using Employment.DataAccess.DatabaseContext;
using Employment.Model.Entities;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using Employment.Sheared.Common;
using Microsoft.EntityFrameworkCore;

namespace Employment.Repositories.Implementation
{
    public class CityRepository : RepositoryBase<City, VMCity, int>, ICityRepository
    {
      

        public CityRepository(EmploymentDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
           
        }

        
    }
}
