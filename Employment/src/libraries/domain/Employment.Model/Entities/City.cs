using Employment.Sheared.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employment.Model.Entities;

public class City : BaseAuditableEntity, IEntity
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public int Id { get; set; }
	/// <summary>
	/// Gets or sets the name of the city.
	/// </summary>
	/// <value>
	/// The name of the city.
	/// </value>
	public string CityName { get; set; } = string.Empty;
	/// <summary>
	/// Gets or sets the state identifier.
	/// </summary>
	/// <value>
	/// The state identifier.
	/// </value>
	public int StateId { get; set; }
	/// <summary>
	/// Gets or sets the state.
	/// </summary>
	/// <value>
	/// The state.
	/// </value>
	
	public State? States { get; set; }
	/// <summary>
	/// Gets or sets the employees.
	/// </summary>
	/// <value>
	/// The employees.
	/// </value>
	public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();


}
