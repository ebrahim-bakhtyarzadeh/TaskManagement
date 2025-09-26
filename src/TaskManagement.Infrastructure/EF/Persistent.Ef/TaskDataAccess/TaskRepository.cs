using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskManagement.Domain.TasksAgg.Models;
using TaskManagement.Domain.TasksAgg.Repository;

namespace TaskManagement.Infrastructure.EF.Persistent.Ef.TaskDataAccess
{
	 public class TaskRepository : ITaskRepository
	 {
		  private readonly TaskManagementContext _shopContext;

		  public TaskRepository(TaskManagementContext shopContext)
		  {
			   _shopContext = shopContext;
		  }

		  public void Add(Tasks entity)
		  {
			   _shopContext.Tasks.Add(entity);
		  }

		  public async Task AddAsync(Tasks entity)
		  {
			   await _shopContext.Tasks.AddAsync(entity);

		  }

		  public async Task AddRange(ICollection<Tasks> entities)
		  {
			   await _shopContext.Tasks.AddRangeAsync(entities);
		  }

		  public bool Exists(Expression<Func<Tasks, bool>> expression)
		  {
			 return  _shopContext.Tasks.Any(expression);
		  }

		  public async Task<bool> ExistsAsync(Expression<Func<Tasks, bool>> expression)
		  {
			   return await _shopContext.Tasks.AnyAsync(expression);

		  }

		  public Tasks? Get(Guid id)
		  {
			   return  _shopContext.Tasks.FirstOrDefault(c=> c.Id == id);

		  }

		  public async Task<Tasks?> GetAsync(Guid id)
		  {
			   return await _shopContext.Tasks.FirstOrDefaultAsync(c => c.Id == id);

		  }

		  public async Task<Tasks?> GetTracking(Guid id)
		  {
			     return  await _shopContext.Tasks.Include(c=>c.Items).AsTracking().FirstOrDefaultAsync(c => c.Id == id);

		  }

		  public async Task<int> Save()
		  {
			return await  _shopContext.SaveChangesAsync();
		  }

		  public void Update(Tasks entity)
		  {
			     _shopContext.Tasks.Add(entity);

		  }
	 }
}
