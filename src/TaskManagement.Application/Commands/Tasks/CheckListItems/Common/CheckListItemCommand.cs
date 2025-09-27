using TaskManagement.Domain.TasksAgg.Models;

namespace TaskManagement.Application.Commands.Tasks.CheckListItems.Common
{
	 public class CheckListItemCommand
	 {
		  public Guid TaskId { get; set; }
		  public string ItemName { get; set; }
		  public string ItemDescription { get; set; }
		  public Priority Priority { get; set; }
	 }
}
