using Common.Application.Result;
using MediatR;
using TaskManagement.Application.Tasks.Commands.CheckListItems.Common;
using TaskManagement.Domain.TasksAgg.Repository;

namespace TaskManagement.Application.Tasks.Commands.CheckListItems.Add
{
	 public class AddCheckListItemCommand : CheckListItemCommand, IRequest<OperationResult>
	 {


		  public class CreateCheckListItemCommandHandler : IRequestHandler<AddCheckListItemCommand, OperationResult>
		  {

			   private readonly ITaskRepository _taskRepository;

			   public CreateCheckListItemCommandHandler(ITaskRepository taskRepository)
			   {
					_taskRepository = taskRepository;
			   }

			   public async Task<OperationResult> Handle(AddCheckListItemCommand request, CancellationToken cancellationToken)
			   {
					var task = await _taskRepository.GetTracking(request.TaskId);
					if (task == null)
						 return OperationResult.NotFound("وظیفه ی مورد نظر برای ثبت ایتم وجود ندارد");
					task.AddCheckListItem(request.ItemName, request.ItemDescription, request.Priority);

					await _taskRepository.Save();
					return OperationResult.Success();
			   }
		  }
	 }
}
