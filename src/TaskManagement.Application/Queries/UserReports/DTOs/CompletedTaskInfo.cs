using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Queries.UserReports.DTOs
{
   public class CompletedTaskInfo 
    {
		public Guid UserId { get; set; }
		public string FullName { get; set; }
		  public Guid TaskId { get; set; }
		  public string TaskName { get; set; }
		  public int CheckListItemCount { get; set; }
		
	}
	
}
