using Common.Application.Result;
using MediatR;
using TaskManagement.Application.Commands.Tasks.CheckListItems.Common;
using TaskManagement.Domain.TasksAgg.Repository;

namespace TaskManagement.Application.Commands.Tasks.CheckListItems.Edit
{
	 public class EditCheckListItemCommand : CheckListItemCommand, IRequest<OperationResult>
	 {
		  public Guid ItemId { get; set; }



		  public class UpdateCheckListItemCommandHandler : IRequestHandler<EditCheckListItemCommand, OperationResult>
		  {
			   private readonly ITaskRepository _taskRepository;
			   public UpdateCheckListItemCommandHandler(ITaskRepository taskRepository)
			   {
					_taskRepository = taskRepository;
			   }

			   public async Task<OperationResult> Handle(EditCheckListItemCommand request, CancellationToken cancellationToken)
			   {
					var task = await _taskRepository.GetTracking(request.TaskId);
					if (task == null)
						 return OperationResult.NotFound("وظیفه ای برای این ایتم وجود ندارد");

					task.UpdateCheckListItem(request.ItemId, request.ItemName, request.ItemDescription, request.Priority);
					await _taskRepository.Save();
					return OperationResult.Success();

			   }
		  }
	 }
}
