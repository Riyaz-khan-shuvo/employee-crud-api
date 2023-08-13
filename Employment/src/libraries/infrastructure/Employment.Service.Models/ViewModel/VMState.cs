using Employment.Sheared.Common;
using System.Text.Json.Serialization;

namespace Employment.Service.Models.ViewModel;

public class VMState:IVM
{
	/// <summary>
	/// Gets or sets the identifier.
	/// </summary>
	/// <value>
	/// The identifier.
	/// </value>
	public int Id { get; set; }
	/// <summary>
	/// Gets or sets the name of the state.
	/// </summary>
	/// <value>
	/// The name of the state.
	/// </value>
	public string StateName { get; set; } = string.Empty;
	/// <summary>
	/// Gets or sets the country identifier.
	/// </summary>
	/// <value>
	/// The country identifier.
	/// </value>
	public int CountryId { get; set; }
	/// <summary>
	/// Gets or sets the country.
	/// </summary>
	/// <value>
	/// The country.
	/// </value>
	public VMCountry ? Country { get; set; }
	/// <summary>
	/// Gets or sets the states.
	/// </summary>
	/// <value>
	/// The states.
	/// </value>
	
	public ICollection<VMCity> Cities { get; set; } = new HashSet<VMCity>();
	public ICollection<VMEmployee> Employees { get; set; } = new HashSet<VMEmployee>();
}
