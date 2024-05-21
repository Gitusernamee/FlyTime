using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public interface IRepository<TEntity> where TEntity : class
{
	ValueTask<TEntity> GetByIdAsync(int id);
	Task<IEnumerable> GetAllAsync();
	Task<IEnumerable> Find(Exception<Func<TEntity, bool>> predicate);
	Task AddAsync(TEntity entity);
	Task AddRangeAsync(IRepository<TEntity> entities);
	void Remove(TEntity entity);
	void RemoveRange(IEmunerrable<TEntity> entities);

}
