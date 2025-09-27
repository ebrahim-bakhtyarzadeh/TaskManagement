using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Queries.UserReports.DTOs;

namespace TaskManagement.Application.Queries.UserReports.Shared
{
  public  interface IUserReportsQueryService
    {
        public Task<List<CompletedTasks>> GetCompletedTasksReport(Guid userId);
        public Task<List<StartedTask>> GetStartedTaskReports(Guid userId);
	}
}
