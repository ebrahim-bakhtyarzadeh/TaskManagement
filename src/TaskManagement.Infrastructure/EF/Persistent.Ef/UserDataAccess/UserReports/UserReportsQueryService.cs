using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public Task<List<CompletedTasks>> GetCompletedTasksReport(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<List<StartedTask>> GetStartedTaskReports(Guid userId)
		{
			throw new NotImplementedException();
		}
	}
}
