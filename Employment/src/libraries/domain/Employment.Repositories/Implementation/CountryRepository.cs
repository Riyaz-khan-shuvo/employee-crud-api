using AutoMapper;
using Employment.DataAccess.Contracts.CommonInterface.BaseInterface;
using Employment.DataAccess.DatabaseContext;
using Employment.Model.Entities;
using Employment.Repositories.Interface;
using Employment.Service.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Repositories.Implementation
{
	public class CountryRepository : RepositoryBase<Country, VMCountry, int>,ICountryRepository
	{
		public CountryRepository(EmploymentDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
		{
		}
	}
}
