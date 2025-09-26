using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.TasksAgg.Models;
using TaskManagement.Domain.UsersAgg.Models;


namespace TaskManagement.Infrastructure.EF.Persistent.Ef
{
	 public class TaskManagementContext : DbContext
	 {
		
		  public TaskManagementContext(DbContextOptions<TaskManagementContext> options) : base(options)
		  {
		  }


		  public DbSet<Tasks> Tasks { get; set; }
		  public DbSet<CheckListItem> CheckListItems { get; set; }
		  public DbSet<User> Users { get; set; }
		  public DbSet<UserToken> UserTokens { get; set; }
		  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		  {
		
			   optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

			   base.OnConfiguring(optionsBuilder);
		  }
		  protected override void OnModelCreating(ModelBuilder modelBuilder)
		  {
			   modelBuilder.Entity<User>()
			 	.HasQueryFilter(p => !p.IsBlockedByAdmin);
			   modelBuilder.Entity<Tasks>().HasQueryFilter(t => !t.Owner.IsBlockedByAdmin);
			   modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagementContext).Assembly);
			

			   base.OnModelCreating(modelBuilder);
		  }

	 }
}
