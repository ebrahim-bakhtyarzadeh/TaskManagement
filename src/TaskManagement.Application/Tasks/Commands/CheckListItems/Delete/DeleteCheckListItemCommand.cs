using Application.Common.Result;
using MediatR;
using TaskManagement.Domain.Models.TasksAgg.Repository;

namespace TaskManagement.Application.Tasks.Commands.CheckListItems.Delete
{
	 public class DeleteCheckListItemCommand : IRequest<UseCaseResult>
	 {

		  public Guid TaskId { get; set; }
		  public Guid ItemId { get; set; }
		  public class DeleteCheckListItemCommandHandler : IRequestHandler<DeleteCheckListItemCommand, UseCaseResult>
		  {

			   private readonly ITaskRepository _taskRepository;

			   public DeleteCheckListItemCommandHandler(ITaskRepository taskRepository)
			   {
					_taskRepository = taskRepository;
			   }

			   public async Task<UseCaseResult> Handle(DeleteCheckListItemCommand request, CancellationToken cancellationToken)
			   {
					var task = await _taskRepository.GetTracking(request.TaskId);
					if (task == null)
						 return UseCaseResult.NotFound();

					task.RemoveCheckListitem(request.ItemId);
					await _taskRepository.Save();
					return UseCaseResult.Success();

			   }
		  }
	 }
}
