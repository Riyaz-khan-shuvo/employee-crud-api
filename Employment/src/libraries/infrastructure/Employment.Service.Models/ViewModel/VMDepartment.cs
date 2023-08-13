using Employment.Sheared.Common;
using System.Text.Json.Serialization;

namespace Employment.Service.Models.ViewModel;

public class VMDepartment:IVM
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

	
	public ICollection<VMEmployee> Employees { get; set; } = new HashSet<VMEmployee>();
}
