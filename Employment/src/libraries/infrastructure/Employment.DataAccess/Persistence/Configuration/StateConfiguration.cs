using Employment.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.DataAccess.Persistence.Configuration;

public class StateConfiguration : IEntityTypeConfiguration<State>
{
	public void Configure(EntityTypeBuilder<State> builder)
	{
		builder.ToTable("States");
		builder.HasKey(x => x.Id);
		builder.HasOne(x=>x.Country).WithMany(x=>x.States).HasForeignKey(x=>x.CountryId).IsRequired(true);
	}
}
