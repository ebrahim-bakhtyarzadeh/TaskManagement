using TaskManagement.Domain.Models.TasksAgg.Models;

namespace TaskManagement.Domain.Models.TasksAgg.Factories
{
	 public interface ITaskFactory
	 {
		  WorkItem CreateTaskForNextWeek(string name, string description);
		  WorkItem CreateTaskForTomorrow(string name, string description);
		  WorkItem CreateTaskForNow(string name, string description);



	 }
	 public class TaskFactory : ITaskFactory
	 {


		  public WorkItem CreateTaskForNow(string name, string description)
		  {
			   return new WorkItem(name, description, DateTime.Now);
		  }

		  public WorkItem CreateTaskForTomorrow(string name, string description)
		  {
			   var startTime = DateTime.Now.Date.AddDays(1);
			   return new WorkItem(name, description, startTime);
		  }

		  public WorkItem CreateTaskForNextWeek(string name, string description)
		  {
			   var startTime = DateTime.Now.Date.AddDays(7);
			   return new WorkItem(name, description, startTime);
		  }


	 }
}
