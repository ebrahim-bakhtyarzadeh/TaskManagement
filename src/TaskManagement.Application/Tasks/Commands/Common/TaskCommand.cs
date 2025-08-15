namespace TaskManagement.Application.Tasks.Commands.Common
{
	 public class TaskCommand
	 {
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
