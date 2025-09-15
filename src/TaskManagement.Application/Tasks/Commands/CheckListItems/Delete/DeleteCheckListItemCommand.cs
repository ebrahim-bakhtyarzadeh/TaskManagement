using Common.Application.Result;
using MediatR;
using TaskManagement.Domain.Models.TasksAgg.Repository;

namespace TaskManagement.Application.Tasks.Commands.CheckListItems.Delete
{
	 public class DeleteCheckListItemCommand : IRequest<OperationResult>
	 {

		  public Guid TaskId { get; set; }
		  public Guid ItemId { get; set; }
		  public class DeleteCheckListItemCommandHandler : IRequestHandler<DeleteCheckListItemCommand, OperationResult>
		  {

			   private readonly ITaskRepository _taskRepository;

			   public DeleteCheckListItemCommandHandler(ITaskRepository taskRepository)
			   {
					_taskRepository = taskRepository;
			   }

			   public async Task<OperationResult> Handle(DeleteCheckListItemCommand request, CancellationToken cancellationToken)
			   {
					var task = await _taskRepository.GetTracking(request.TaskId);
					if (task == null)
						 return OperationResult.NotFound();

					task.RemoveCheckListitem(request.ItemId);
					await _taskRepository.Save();
					return OperationResult.Success();

			   }
		  }
	 }
}
