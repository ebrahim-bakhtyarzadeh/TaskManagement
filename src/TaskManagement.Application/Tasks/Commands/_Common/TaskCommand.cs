namespace TaskManagement.Application.Tasks.Commands._Common
{
	 public class TaskCommand
	 {
		  public Guid userId { get; set; }
		  public string Name { get; set; }
		  public string Description { get; set; }
		  public TaskStartTimes StartTime { get; set; }
	 }
	 public enum TaskStartTimes
	 {
		  ForNow = 0,
		  ForTommorow = 1,
		  ForNextWeek = 2
	 }


}
