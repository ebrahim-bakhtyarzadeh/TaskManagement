using TaskManagement.Domain.Models.TasksAgg.Models;

namespace TaskManagement.Domain.Models.TasksAgg.Factories
{
	 public interface ITaskFactory
	 {
		  Tasks CreateTaskForNextWeek(string name, string description);
		  Tasks CreateTaskForTomorrow(string name, string description);
		  Tasks CreateTaskForNow(string name, string description);



	 }
	 public class TaskFactory : ITaskFactory
	 {


		  public Tasks CreateTaskForNow(string name, string description)
		  {
			   return new Tasks(name, description, DateTime.Now);
		  }

		  public Tasks CreateTaskForTomorrow(string name, string description)
		  {
			   var startTime = DateTime.Now.Date.AddDays(1);
			   return new Tasks(name, description, startTime);
		  }

		  public Tasks CreateTaskForNextWeek(string name, string description)
		  {
			   var startTime = DateTime.Now.Date.AddDays(7);
			   return new Tasks(name, description, startTime);
		  }


	 }
}
