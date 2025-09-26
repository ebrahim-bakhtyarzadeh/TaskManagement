using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Application.Users.Queries.Shared;
using TaskManagement.Domain.UsersAgg.Repository;

namespace TaskManagement.Infrastructure.EF.Persistent.Ef.UserDataAccess
{
	 public class UserRepository : IUserRepository			
	 {
		  private  TaskManagementContext _shopContext;

		  public UserRepository(TaskManagementContext shopContext)
		  {
			   _shopContext = shopContext;
		  }
		  public void Add(Domain.UsersAgg.Models.User entity)
		  {
			   _shopContext.Users.Add(entity);

		  }

		  public async Task AddAsync(Domain.UsersAgg.Models.User entity)
		  {
			   await _shopContext.Users.AddAsync(entity);
		  }

		  public async Task AddRange(ICollection<Domain.UsersAgg.Models.User> entities)
		  {
			   await _shopContext.Users.AddRangeAsync(entities);

		  }

		  public bool Exists(Expression<Func<Domain.UsersAgg.Models.User, bool>> expression)
		  {
			   return _shopContext.Users.Any(expression);
		  }

		  public async Task<bool> ExistsAsync(Expression<Func<Domain.UsersAgg.Models.User, bool>> expression)
		  {
			   return await _shopContext.Users.AnyAsync(expression);

		  }

		  public Domain.UsersAgg.Models.User? Get(Guid id)
		  {
			   return _shopContext.Users.FirstOrDefault(c => c.Id == id);
		  }

		  public Task<Domain.UsersAgg.Models.User?> GetAsync(Guid id)
		  {
			   return _shopContext.Users.FirstOrDefaultAsync(x => x.Id == id);
		  }

		  public Task<Domain.UsersAgg.Models.User?> GetTracking(Guid id)
		  {
			   return _shopContext.Users.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
		  }

		  public async Task<int> Save()
		  {
			   return await _shopContext.SaveChangesAsync();
		  }

		  public void Update(Domain.UsersAgg.Models.User entity)
		  {
			   _shopContext.Users.Update(entity);
		  }
	 }
}
