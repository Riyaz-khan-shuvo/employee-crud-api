using Employment.DataAccess.Contracts.CommonInterface;
using Employment.Model.Entities;
using Employment.Service.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employment.Repositories.Interface
{
	public interface ICountryRepository : IRepository<Country,VMCountry, int>
	{

	}
}
