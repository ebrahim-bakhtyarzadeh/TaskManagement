using Common.Application.Result;
using MediatR;
using TaskManagement.Domain.TasksAgg.Repository;

namespace TaskManagement.Application.Commands.Tasks.CheckListItems.ChangeState
{
	 public class ChangeStateCommand:IRequest<OperationResult>
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

			   public ChangeStateCommandHandler(ITaskRepository taskRepository)
			   {
					_TaskRepository = taskRepository;
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
				 
					return OperationResult.Success("ایتم به حالت انجام شده رفت");
			   }
		  }
	 }
	 
}
