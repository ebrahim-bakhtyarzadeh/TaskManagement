using Common.Domain.Models;
using System.Linq.Expressions;

namespace Common.Domain
{
	 public interface IBaseRepository<T> where T : Entity
	 {
		  Task<T?> GetAsync(Guid id);

		  Task<T?> GetTracking(Guid id);

		  Task AddAsync(T entity);
		  void Add(T entity);

		  Task AddRange(ICollection<T> entities);

		  void Update(T entity);

		  Task<int> Save();

		  Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

		  bool Exists(Expression<Func<T, bool>> expression);

		  T? Get(Guid id);
	 }
}
