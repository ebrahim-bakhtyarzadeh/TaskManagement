using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Tasks.Queries.DTOs;
using TaskManagement.Application.Tasks.Queries.Shared;

namespace TaskManagement.Infrastructure.EF.Persistent.Ef.TaskDataAccess
{
	 public class TaskQueryService : ITaskQueryService
	 {
		  private readonly TaskManagementContext _context;

		  public TaskQueryService(TaskManagementContext context)
		  {
			   _context = context;
		  }

		  public async Task<List<TaskDto>> GetAllTasks(Guid userId, CancellationToken cancellationToken)
		  {
			   return await _context.Tasks.Include(c => c.Owner).Include(c => c.Items).Where(c => c.UserId == userId).Select(c => new TaskDto
			   {
					Description = c.Description,

					Name = c.Name,
					OwnerName = c.Owner.FirstName + " " + c.Owner.LastName,
					StartTime = c.StartTime,
					Status = c.Status.ToString(),
					Items = c.Items.Select(i=> new CheckListitemDto()
					{
						 Description= i.Description,
						 IsCompleted= i.IsCompleted,
						 Name= i.Name,
						 Priority = i.Priority.ToString()
					})	.ToList()			
			   }).ToListAsync();

		  }

		  public async Task<List<TaskDto>> GetTasksByStatus(Guid userId, TaskStatus status, CancellationToken cancellationToken)
		  {
			   var tasks= await _context.Tasks.Include(c => c.Owner).Include(c => c.Items).Where(c => c.UserId == userId && (int)c.Status == (int)status).Select(c => new TaskDto
			   {
					Description = c.Description,

					Name = c.Name,
					OwnerName = c.Owner.FirstName + " " + c.Owner.LastName,
					StartTime = c.StartTime,
					Status = c.Status.ToString(),
					Items = c.Items.Select(i => new CheckListitemDto()
					{
						 Description = i.Description,
						 IsCompleted = i.IsCompleted,
						 Name = i.Name,
						 Priority = i.Priority.ToString()
					}).ToList()
			   }).ToListAsync();

			   return tasks;
		  }
	 }
}
