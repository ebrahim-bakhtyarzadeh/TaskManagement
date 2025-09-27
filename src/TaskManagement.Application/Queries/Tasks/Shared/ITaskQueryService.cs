using TaskManagement.Application.Queries.Tasks.DTOs;

namespace TaskManagement.Application.Queries.Tasks.Shared
{
	 public interface ITaskQueryService
	 {
		  Task<List<TaskDto>> GetAllTasks(Guid userId , CancellationToken cancellationToken);
		  Task<List<TaskDto>> GetTasksByStatus(Guid userId , TaskStatus status,CancellationToken cancellationToken);
	 }
}
