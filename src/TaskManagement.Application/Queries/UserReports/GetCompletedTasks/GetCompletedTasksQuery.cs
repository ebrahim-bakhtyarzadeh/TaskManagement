using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Queries.UserReports.GetCompletedTasks
{
    class GetCompletedTasksQuery
    {
	   private Guid UserId { get; set; }
		public GetCompletedTasksQuery(Guid userId)
		{
			  UserId = userId;
		}




		internal class GetCompletedTasksQueryHandler
		{
		}
	}
}
