using Common.Domain;
using TaskManagement.Domain.Models.TasksAgg.Models;

namespace TaskManagement.Domain.Models.TasksAgg.Repository
{
	 public interface ITaskRepository : IBaseRepository<WorkItem>
	 {
	 }
}
