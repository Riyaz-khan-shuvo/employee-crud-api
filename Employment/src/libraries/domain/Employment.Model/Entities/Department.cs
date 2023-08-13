using Employment.Sheared.Common;

namespace Employment.Model.Entities;

public class Department : BaseAuditableEntity, IEntity
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public int Id { get; set; }

	/// <summary>
	/// Gets or sets the name of the department.
	/// </summary>
	/// <value>
	/// The name of the department.
	/// </value>
	public string DepartmentName { get; set; } = string.Empty;
	
	public ICollection<Employee> Employees { get; set; }=new HashSet<Employee>();
}
