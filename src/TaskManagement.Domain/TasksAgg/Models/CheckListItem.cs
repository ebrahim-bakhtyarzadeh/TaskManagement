using Common.Domain.Models;
namespace TaskManagement.Domain.TasksAgg.Models
{
	 public class CheckListItem : Entity
	 {
		  public string Name { get; private set; }
		  public string Description { get; private set; }
		  public Priority Priority { get; private set; }
		  public bool IsCompleted { get; private set; }
		  public Guid TaskId { get; private set; }
		  public Tasks Task { get; private set; }
		  public CheckListItem(Guid taskId, string name, string description, Priority priority)
		  {
			   TaskId = taskId;
			   Name = name;
			   Description = description;
			   Priority = priority;
			   IsCompleted = false;
		  }
		  public CheckListItem UpdateName(string name)
		  {
			   Name = name;
			   return this;
		  }
		  public CheckListItem UpdateDescription(string description)
		  {
			   Description = description;
			   return this;
		  }
		  public CheckListItem UpdatePriority(Priority priority)
		  {
			   Priority = priority;
			   return this;
		  }
		  public CheckListItem CheckListItemCompleted()
		  {
			   IsCompleted = true;
			
			   return this;
		  }


	 }
	 public enum Priority
	 {
		  Low = 1,
		  Medium = 2,
		  High = 3
	 }
}
