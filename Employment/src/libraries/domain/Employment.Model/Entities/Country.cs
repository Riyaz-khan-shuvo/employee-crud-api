using Employment.Sheared.Common;
namespace Employment.Model.Entities;
public class Country : BaseAuditableEntity, IEntity
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public int Id { get; set; }
	/// <summary>
	/// Gets or sets the name of the country.
	/// </summary>
	/// <value>
	/// The name of the country.
	/// </value>
	public string CountryName { get; set; } = string.Empty;

	public ICollection<State>  States { get; set; } = new HashSet<State>();
	public ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();
}
