using Employment.Sheared.Enums;

namespace Employment.Sheared.Common;

public class BaseAuditableEntity
{
	/// <summary>
	/// Gets or sets the created.
	/// </summary>
	/// <value>
	/// The created.
	/// </value>
	public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;

	/// <summary>
	/// Gets or sets the created by.
	/// </summary>
	/// <value>
	/// The created by.
	/// </value>
	public string CreatedBy { get; set; } = string.Empty;

	/// <summary>
	/// Gets or sets the last modified.
	/// </summary>
	/// <value>
	/// The last modified.
	/// </value>
	public DateTimeOffset? LastModified { get; set; }

	/// <summary>
	/// Gets or sets the last modified by.
	/// </summary>
	/// <value>
	/// The last modified by.
	/// </value>
	public string? LastModifiedBy { get; set; }
	/// <summary>
	/// Gets or sets the status.
	/// </summary>
	/// <value>
	/// The status.
	/// </value>
	public EntityStatus Status { get; set; }
}
