using MediatR;
using TaskManagement.Application.Queries.Tasks.DTOs;
using TaskManagement.Application.Queries.Tasks.Shared;

namespace TaskManagement.Application.Queries.Tasks.GetAllTasks
{
	 public class GetAllTasksByUserIDQueryHandler : IRequestHandler<GetAllTasksByUserIdQuery, List<TaskDto>?>
	 {
		  private readonly ITaskQueryService _taskQueryService;
		  public GetAllTasksByUserIDQueryHandler(ITaskQueryService taskQueryService)
		  {
			   _taskQueryService = taskQueryService;
		  }

		  public async Task<List<TaskDto>?> Handle(GetAllTasksByUserIdQuery request, CancellationToken cancellationToken)
		  {
			   return await _taskQueryService.GetAllTasks(request.userId, cancellationToken);
		  }
	 }
}
