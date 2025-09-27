using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Queries.UserReports.DTOs;
using TaskManagement.Application.Queries.UserReports.Shared;

namespace TaskManagement.Infrastructure.EF.Persistent.Ef.UserDataAccess.UserReports
{
	public class UserReportsQueryService : IUserReportsQueryService
	{
		private readonly TaskManagementContext _Context;

		public UserReportsQueryService(TaskManagementContext context)
		{
			_Context = context;
		}

		public async Task<List<CompletedTaskInfo>> GetCompletedTasksReport(Guid userId)
		{
			  return await _Context.Tasks.Include(c => c.Owner).Include(c => c.Items).Where(c => c.UserId == userId && c.Status == Domain.TasksAgg.Models.TaskStatus.Completed).Select(c => new CompletedTaskInfo
			   {
					FullName = c.Owner.FirstName + " " + c.Owner.LastName,
					UserId = c.UserId,
				  	CheckListItemCount= c.Items.Count(),
					TaskId= c.Id,
					TaskName= c.Name,
					
			   }).ToListAsync();
		}

		public async Task<List<StartedTaskInfo>> GetStartedTaskReports(Guid userId)
		{
			   return await _Context.Tasks.Include(c => c.Owner).Include(c => c.Items).Where(c => c.UserId == userId && c.Status == Domain.TasksAgg.Models.TaskStatus.InProgress).Select(c => new StartedTaskInfo
			   {
					FullName = c.Owner.FirstName + " " + c.Owner.LastName,
					UserId = c.UserId,
					CheckListItemCount = c.Items.Count(),
					TaskId = c.Id,
					TaskName = c.Name,

			   }).ToListAsync();
		  }
	}
}
