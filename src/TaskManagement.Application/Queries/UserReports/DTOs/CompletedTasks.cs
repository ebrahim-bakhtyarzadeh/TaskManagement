using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Queries.UserReports.DTOs
{
   public class CompletedTasks 
    {
		public Guid UserId { get; set; }
		public string FullName { get; set; }
		public List<CompletedTaskData> TasksData{ get; set; }
	}
	public class CompletedTaskData
	{
		public Guid TaskId { get; set; }
		public string TaskName { get; set; }
		public int CheckListItemCount { get; set; }
	}
}
