using Common.Application.Result;
using Common.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.TasksAgg.Models;
using TaskManagement.Domain.TasksAgg.Repository;

namespace TaskManagement.Application.Tasks.Commands.CheckListItems.ChangeState
{
	 public class ChangeStateCommand			 :IRequest<OperationResult>
	 {
		  public Guid TaskId { get; set; }
		  public Guid CheckListItemId { get; set; }

		  public ChangeStateCommand(Guid checkListItemId, Guid taskId)
		  {
			   CheckListItemId = checkListItemId;
			   TaskId = taskId;
		  }

		  class ChangeStateCommandHandler : IRequestHandler<ChangeStateCommand, OperationResult>
		  {
			   private readonly ITaskRepository _TaskRepository;
			   private readonly IEventSource _EventSource;

			   public ChangeStateCommandHandler(ITaskRepository taskRepository, IEventSource eventSource)
			   {
					_TaskRepository = taskRepository;
					_EventSource = eventSource;
			   }

			   public async Task<OperationResult> Handle(ChangeStateCommand request, CancellationToken cancellationToken)
			   {
					var task =await _TaskRepository.GetTracking(request.TaskId);
					if (task == null)
					{
						 return  OperationResult.NotFound("وظیفه ای برای این ایتم یافت نشد");
					}
				   task.  MarkCheckListItemAsCompleted(request.CheckListItemId);
				await	_TaskRepository.Save();
				  var events = 	task.Events;
				await	_EventSource.SaveEvent(nameof(Tasks), task.Id.ToString(),cancellationToken, events );
					return OperationResult.Success("ایتم به حالت انجام شده رفت");
			   }
		  }
	 }
	 
}
