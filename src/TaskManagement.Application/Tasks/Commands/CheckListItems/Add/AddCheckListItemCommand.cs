using Application.Common.Result;
using MediatR;
using TaskManagement.Application.Tasks.Commands.CheckListItems.Common;
using TaskManagement.Domain.Models.TasksAgg.Repository;

namespace TaskManagement.Application.Tasks.Commands.CheckListItems.Add
{
	 public class AddCheckListItemCommand : CheckListItemCommand, IRequest<UseCaseResult>
	 {


		  public class CreateCheckListItemCommandHandler : IRequestHandler<AddCheckListItemCommand, UseCaseResult>
		  {

			   private readonly ITaskRepository _taskRepository;

			   public CreateCheckListItemCommandHandler(ITaskRepository taskRepository)
			   {
					_taskRepository = taskRepository;
			   }

			   public async Task<UseCaseResult> Handle(AddCheckListItemCommand request, CancellationToken cancellationToken)
			   {
					var task = await _taskRepository.GetTracking(request.TaskId);
					if (task == null)
						 return UseCaseResult.NotFound("وظیفه ی مورد نظر برای ثبت ایتم وجود ندارد");
					task.AddCheckListItem(request.ItemName, request.ItemDescription, request.Priority);

					await _taskRepository.Save();
					return UseCaseResult.Success();
			   }
		  }
	 }
}
