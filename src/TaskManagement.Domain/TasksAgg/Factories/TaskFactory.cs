using TaskManagement.Domain.TasksAgg.Models;

namespace TaskManagement.Domain.TasksAgg.Factories
{
	 public class TaskFactory : ITaskFactory
	 {
		  public Tasks CreateTaskForNow(Guid userId,string name, string description)
		  {
			   return new Tasks(userId,name, description, DateTime.Now);
		  }

		  public Tasks CreateTaskForTomorrow(Guid userId, string name, string description)
		  {
			   var startTime = DateTime.Now.Date.AddDays(1);
			   return new Tasks(userId, name, description, startTime);
		  }

		  public Tasks CreateTaskForNextWeek(Guid userId,string name, string description)
		  {
			   var startTime = DateTime.Now.Date.AddDays(7);
			   return new Tasks(userId, name, description, startTime);
		  }


	 }
}
