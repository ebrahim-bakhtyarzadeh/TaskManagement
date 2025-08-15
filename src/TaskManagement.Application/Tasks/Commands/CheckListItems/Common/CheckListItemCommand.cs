using TaskManagement.Domain.Models.TasksAgg.Models;

namespace TaskManagement.Application.Tasks.Commands.CheckListItems.Common
{
	 public class CheckListItemCommand
	 {
		  public Guid TaskId { get; set; }
		  public string ItemName { get; set; }
		  public string ItemDescription { get; set; }
		  public Priority Priority { get; set; }
	 }
}
