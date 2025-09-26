using MediatR;
using TaskManagement.Application.Tasks.Queries.DTOs;
using TaskManagement.Application.Tasks.Queries.Shared;

namespace TaskManagement.Application.Tasks.Queries.GetAllTasks
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
