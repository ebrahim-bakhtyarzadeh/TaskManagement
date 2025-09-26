using TaskManagement.Application.Tasks.Queries.DTOs;

namespace TaskManagement.Application.Tasks.Queries.Shared
{
	 public interface ITaskQueryService
	 {
		  Task<List<TaskDto>> GetAllTasks(Guid userId , CancellationToken cancellationToken);
		  Task<List<TaskDto>> GetTasksByStatus(Guid userId , TaskStatus status,CancellationToken cancellationToken);
	 }
}
