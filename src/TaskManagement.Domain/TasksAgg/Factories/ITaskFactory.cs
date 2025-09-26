using TaskManagement.Domain.TasksAgg.Models;

namespace TaskManagement.Domain.TasksAgg.Factories
{
	 public interface ITaskFactory
	 {
		  Tasks CreateTaskForNextWeek(Guid userId, string name, string description);
		  Tasks CreateTaskForTomorrow(Guid userId, string name, string description);
		  Tasks CreateTaskForNow(Guid userId, string name, string description);



	 }
}
