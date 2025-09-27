using Common.EndPoint.API;
using Common.EndPoint.API.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Commands.Tasks.CheckListItems.Add;
using TaskManagement.Application.Commands.Tasks.CheckListItems.ChangeState;
using TaskManagement.Application.Commands.Tasks.CheckListItems.Delete;
using TaskManagement.Application.Commands.Tasks.CheckListItems.Edit;
using TaskManagement.Application.Commands.Tasks.Create;
using TaskManagement.Application.Commands.Tasks.Edit;
using TaskManagement.Application.Queries.Tasks.DTOs;
using TaskManagement.Application.Queries.Tasks.GetTasksByStatus;
using TaskManagement.Application.Tasks.Queries.GetAllTasks;
using TaskManagement.WebApi.Security;

namespace TaskManagement.WebApi.Controllers
{
   
    public class TaskController : ApiController
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }
		  #region Commands
		  [PermissionChecker]
		  [HttpPost]
		  public async Task<ApiResult> CreateTask([FromBody] CreateTaskCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);

        }
        [HttpPut]

        public async Task<ApiResult> UpdateTask([FromBody] EditTaskCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }                                                                                                                                        

        [HttpPost("CheckListitem")]
        public async Task<ApiResult> AddCheckListItem([FromBody] AddCheckListItemCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }

        [HttpPut("CheckListItem")]
        public async Task<ApiResult> EditCheckListItem([FromBody]EditCheckListItemCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }


        [HttpDelete("CheckListitem")]
        public async Task<ApiResult> DeleteCheckListItem([FromBody]DeleteCheckListItemCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }
          [HttpPost("CompleteCheckListItem")]
          public async Task<ApiResult> CompleteCheckListIetm([FromBody] ChangeStateCommand command)
          {
			   var res = await _mediator.Send(command);
			   return CommandResult(res);
		  }
          #endregion

          #region Queries
          [HttpGet("{userId}")]
          public async  Task<ApiResult<List<TaskDto>?>> GetAllTaskByUserId (Guid userId , CancellationToken cancellationToken)
          {
               var res =await _mediator.Send(new GetAllTasksByUserIdQuery(userId), cancellationToken);
               return QueryResult(res);
          }
		  [HttpGet("GetByStatusAndUserId")]
		  public async Task<ApiResult<List<TaskDto>?>> GetAllTaskByStatus([FromQuery]GetTasksByStatusQuery info, CancellationToken cancellationToken)
		  {
			   var res = await _mediator.Send(info, cancellationToken);
			   return QueryResult(res);
		  }
		  #endregion


	 }
}
