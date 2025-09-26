using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.TasksAgg.Models;

namespace TaskManagement.Application.Tasks.Queries.DTOs
{
	 public class TaskDto
	 {
		  public string Name { get; set; }
	 	  public string Description { get;  set; }
		  public string OwnerName { get; set; }
		  public DateTime StartTime { get; set; }
		  public string Status { get;  set; }
		  public List<CheckListitemDto>? Items { get;  set; }

	 }
	 public  class CheckListitemDto
	 {
		  public string Name { get;  set; }
		  public string Description { get;  set; }
		  public string Priority { get;  set; }
		  public bool IsCompleted { get;  set; }
	 }
}
