using Employment.Model.Entities;
using Employment.Sheared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.DataAccess.Persistence.Configuration;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
	public void Configure(EntityTypeBuilder<Department> builder)
	{
		builder.ToTable("Departments");
		builder.HasKey(x => x.Id);
		builder.HasData(new
		{
			Id = 1,
			DepartmentName="IT",
			Created = DateTimeOffset.Now,
			CreatedBy = "1",
			Status = EntityStatus.Created
		}) ;
	}
}
