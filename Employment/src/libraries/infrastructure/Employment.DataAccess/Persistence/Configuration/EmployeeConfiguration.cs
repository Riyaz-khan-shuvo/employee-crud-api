using Employment.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.DataAccess.Persistence.Configuration;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable("Employees");
		builder.HasKey(e => e.Id);
		builder.HasOne(x => x.Country).WithMany(x => x.Employees).HasForeignKey(x => x.CountryId).IsRequired(true);
		builder.HasOne(x => x.State).WithMany(x => x.Employees).HasForeignKey(e => e.StateId).IsRequired(true);
		builder.HasOne(x => x.City).WithMany(x => x.Employees).HasForeignKey(c => c.CityId).IsRequired(true);
		builder.HasOne(x=>x.Department).WithMany(x=>x.Employees).HasForeignKey(d=>d.DepartmentId).IsRequired(true);
	}
}
