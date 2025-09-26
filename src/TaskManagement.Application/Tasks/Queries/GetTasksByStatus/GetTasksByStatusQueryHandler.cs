using MediatR;
using TaskManagement.Application.Tasks.Queries.DTOs;
using TaskManagement.Application.Tasks.Queries.Shared;

namespace TaskManagement.Application.Tasks.Queries.GetTasksByStatus
{
	 internal class GetTasksByStatusQueryHandler : IRequestHandler<GetTasksByStatusQuery, List<TaskDto>>
	 {
		  private readonly ITaskQueryService _taskQueryService;

		  public GetTasksByStatusQueryHandler(ITaskQueryService taskQueryService)
		  {
			   _taskQueryService = taskQueryService;
		  }

		  public async Task<List<TaskDto>> Handle(GetTasksByStatusQuery request, CancellationToken cancellationToken)
		  {
			   return await _taskQueryService.GetTasksByStatus(request.userId, request.status,cancellationToken);
		  }
	 }
}
