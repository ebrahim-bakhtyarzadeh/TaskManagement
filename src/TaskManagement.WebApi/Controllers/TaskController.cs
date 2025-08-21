using Common.EndPoint.API;
using Common.EndPoint.API.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Tasks.Commands.CheckListItems.Add;
using TaskManagement.Application.Tasks.Commands.CheckListItems.Delete;
using TaskManagement.Application.Tasks.Commands.CheckListItems.Edit;
using TaskManagement.Application.Tasks.Commands.Create;
using TaskManagement.Application.Tasks.Commands.Edit;

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

        [HttpPost]

        public async Task<ApiResult> CreateTask(CreateTaskCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);

        }
        [HttpPut]

        public async Task<ApiResult> UpdateTask(EditTaskCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }

        [HttpPost("CheckListitem")]
        public async Task<ApiResult> AddCheckListItem(AddCheckListItemCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }

        [HttpPut("CheckListItem")]
        public async Task<ApiResult> EditCheckListItem(EditCheckListItemCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }


        [HttpDelete("CheckListitem")]
        public async Task<ApiResult> DeleteCheckListItem(DeleteCheckListItemCommand command)
        {
            var res = await _mediator.Send(command);
            return CommandResult(res);
        }

        #endregion


    }
}
