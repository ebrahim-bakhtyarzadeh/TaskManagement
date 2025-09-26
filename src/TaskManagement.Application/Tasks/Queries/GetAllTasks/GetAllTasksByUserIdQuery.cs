using MediatR;
using TaskManagement.Application.Tasks.Queries.DTOs;

namespace TaskManagement.Application.Tasks.Queries.GetAllTasks
{
	 public record GetAllTasksByUserIdQuery(Guid userId) : IRequest<List<TaskDto>?>;
}
