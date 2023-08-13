using Employment.Sheared.Common;
using System.Linq.Expressions;

namespace Employment.DataAccess.Contracts.CommonInterface;

public interface IRepository<TEntity, IModel, T> 
	where TEntity : class, IEntity<T>, new()
	where IModel : class, IVM<T>, new()
	where T : IEquatable<T>
{
	/// <summary>Gets the by identifier asynchronous.</summary>
	/// <param name="id">The identifier.</param>
	/// <returns>
	///   <br />
	/// </returns>
	public Task<IModel> GetByIdAsync(T id);
	/// <summary>
	/// Gets all asynchronous.
	/// </summary>
	/// <returns></returns>
	public Task<IEnumerable<IModel>> GetAllAsync();

	public Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);

    /// <summary>
    /// Deletes the asynchronous.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    public Task DeleteAsync(TEntity entity);
	/// <summary>
	/// Deletes the asynchronous.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <returns></returns>
	public Task <IModel> DeleteAsync(T id);
	/// <summary>
	/// Updates the asynchronous.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <param name="entity">The entity.</param>
	/// <returns></returns>
	public Task<IModel> UpdateAsync(T id, TEntity entity);
	/// <summary>
	/// Inserts the asynchronous.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns></returns>
	public Task<IModel> InsertAsync(TEntity entity);
}
