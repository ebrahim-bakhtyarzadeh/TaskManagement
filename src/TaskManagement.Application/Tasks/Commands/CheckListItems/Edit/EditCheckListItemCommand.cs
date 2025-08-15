using Application.Common.Result;
using MediatR;
using TaskManagement.Application.Tasks.Commands.CheckListItems.Common;
using TaskManagement.Domain.Models.TasksAgg.Repository;

namespace TaskManagement.Application.Tasks.Commands.CheckListItems.Edit
{
	 public class EditCheckListItemCommand : CheckListItemCommand, IRequest<UseCaseResult>
	 {
		  public Guid ItemId { get; set; }



		  public class UpdateCheckListItemCommandHandler : IRequestHandler<EditCheckListItemCommand, UseCaseResult>
		  {
			   private readonly ITaskRepository _taskRepository;
			   public UpdateCheckListItemCommandHandler(ITaskRepository taskRepository)
			   {
					_taskRepository = taskRepository;
			   }

			   public async Task<UseCaseResult> Handle(EditCheckListItemCommand request, CancellationToken cancellationToken)
			   {
					var task = await _taskRepository.GetTracking(request.TaskId);
					if (task == null)
						 return UseCaseResult.NotFound("وظیفه ای برای این ایتم وجود ندارد");

					task.UpdateCheckListItem(request.ItemId, request.ItemName, request.ItemDescription, request.Priority);
					await _taskRepository.Save();
					return UseCaseResult.Success();

			   }
		  }
	 }
}
