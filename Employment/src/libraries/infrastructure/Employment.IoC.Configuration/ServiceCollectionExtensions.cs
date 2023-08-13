using Employment.Core;
using Employment.Core.Behaviour;
using Employment.Core.Mappers;
using Employment.DataAccess.DatabaseContext;
using Employment.Repositories.Implementation;
using Employment.Repositories.Interface;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Employment.IoC.Configuration;
public static class ServiceCollectionExtensions
{
	public static IServiceCollection MapCore(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<EmploymentDbContext>(optins => optins.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
		services.AddAutoMapper(typeof(CommonMapper).Assembly);
		services.AddTransient<IEmployeeRepository, EmployeeRepository>();
		services.AddTransient<IDepartmentRepository, DepartmentRepository>();
		services.AddTransient<ICityRepository, CityRepository>();
		services.AddTransient<ISateRepository, SateRepository>();
		services.AddTransient<ICountryRepository, CountryRepository>();


		//services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(ICore).Assembly));
		services.AddValidatorsFromAssembly(typeof(ICore).Assembly);
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssemblies(typeof(ICore).Assembly);
			//cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
			//cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
			cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
			//cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
			// cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<>));
		});
       

        return services;
	}
}
