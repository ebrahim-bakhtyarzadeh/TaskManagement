using Common.EndPoint.API;
using Common.EndPoint.API.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Queries.UserReports.DTOs;
using TaskManagement.Application.Queries.UserReports.GetCompletedTasks;
using TaskManagement.Application.Queries.UserReports.GetStartedTasks;

namespace TaskManagement.WebApi.Controllers
{

	 public class UserReportsController : ApiController
	 {
		  private readonly IMediator _mediator;

		  public UserReportsController(IMediator mediator)
		  {
			   _mediator = mediator;
		  }
		  [HttpGet("GetCompletedTasksByUserId")]
		  public async Task<ApiResult<List<CompletedTaskInfo>>> GetCompletedTasksByUserId([FromQuery] Guid userId, CancellationToken cancellationToken)
		  {
			   var info = await _mediator.Send(new GetCompletedTasksQuery(userId));
			   return QueryResult(info.Data);
		  }
		  [HttpGet("GetStartedTasksByUserId")]
		  public async Task<ApiResult<List<StartedTaskInfo>>> GetStartedTasksByUserId([FromQuery] Guid userId, CancellationToken cancellationToken)
		  {
			   var info = await _mediator.Send(new GetStartedTasksQuery(userId));
			   return QueryResult(info.Data);
		  }
	 }
}
