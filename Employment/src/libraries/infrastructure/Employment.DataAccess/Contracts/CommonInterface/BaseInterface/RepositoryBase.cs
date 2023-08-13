using AutoMapper;
using Employment.DataAccess.DatabaseContext;
using Employment.Sheared.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Employment.DataAccess.Contracts.CommonInterface.BaseInterface;

public class RepositoryBase<TEntity, IModel, T> : IRepository<TEntity, IModel, T>
	where TEntity : class, IEntity<T>, new()
	where IModel : class, IVM<T>, new()
	where T : IEquatable<T>
{

	private readonly EmploymentDbContext _dbContext;
	private readonly IMapper _mapper;
	/// <summary>
	/// Repository Base
	/// </summary>
	/// <param name="dbContext"></param>
	/// <param name="mapper"></param>
	public RepositoryBase(EmploymentDbContext dbContext, IMapper mapper)
	{
		_dbContext = dbContext;
		_mapper = mapper;
		DbSet = _dbContext.Set<TEntity>();
	}
	/// <summary>
	/// Gets the database set.
	/// </summary>
	/// <value>
	/// The database set.
	/// </value>
	public DbSet<TEntity> DbSet { get; }
	/// <summary>
	/// Deletes the asynchronous.
	/// </summary>
	/// <param name="entity">The entity.</param>
	public async Task DeleteAsync(TEntity entity)
	{
		DbSet.Remove(entity);
		await _dbContext.SaveChangesAsync();
	}
	/// <summary>
	/// Deletes the asynchronous.
	/// </summary>
	/// <param name="id">The identifier.</param>
	public async Task<IModel> DeleteAsync(T id)
	{
		var entity = await DbSet.FindAsync(id);
		if (entity != null)
		{
			DbSet.Remove(entity);
			await _dbContext.SaveChangesAsync();
		}
		return _mapper.Map<IModel>(entity);
	}
	/// <summary>
	/// Gets all asynchronous.
	/// </summary>
	/// <returns></returns>
	public async Task<IEnumerable<IModel>> GetAllAsync()
	{
		var entities = await DbSet.ToListAsync();


		return _mapper.Map<IEnumerable<IModel>>(entities);
	}

    public async Task<List<IModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
		var entities = await includes.Aggregate(
            _dbContext.Set<TEntity>().AsQueryable(), (current, include) => current.Include(include))
            .ToListAsync().ConfigureAwait(true);

		return _mapper.Map<List<IModel>>(entities);
	}

    /// <summary>
    /// Gets the by identifier asynchronous.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>
    /// <br />
    /// </returns>
    public async Task<IModel> GetByIdAsync(T id)
	{
		var data = await DbSet.FindAsync(id);
		return _mapper.Map<IModel>(data);
	}

	/// <summary>
	/// Inserts the asynchronous.
	/// </summary>
	/// <param name="entity">The entity.</param>
	/// <returns></returns>
	public async Task<IModel> InsertAsync(TEntity entity)
	{
		await DbSet.AddAsync(entity);
		await _dbContext.SaveChangesAsync();
		return _mapper.Map<IModel>(entity);
	}

	/// <summary>
	/// Updates the asynchronous.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <param name="entity">The entity.</param>
	/// <returns></returns>
	/// <exception cref="System.ArgumentNullException">entity</exception>
	public async Task<IModel> UpdateAsync(T id, TEntity entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		var exist = await DbSet.FindAsync(id);
		if (exist != null)
		{
			DbSet.Entry(exist).CurrentValues.SetValues(entity);
			await _dbContext.SaveChangesAsync();
		}
		return _mapper.Map<IModel>(entity);
	}
}
