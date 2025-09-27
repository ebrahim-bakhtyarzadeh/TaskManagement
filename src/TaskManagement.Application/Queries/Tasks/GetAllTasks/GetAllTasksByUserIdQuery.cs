using MediatR;
using TaskManagement.Application.Queries.Tasks.DTOs;

namespace TaskManagement.Application.Queries.Tasks.GetAllTasks
{
	 public record GetAllTasksByUserIdQuery(Guid userId) : IRequest<List<TaskDto>?>;
}
