using Common.Application.Result;
using MediatR;
using TaskManagement.Application.Tasks.Commands._Common;
using TaskManagement.Domain.Models.TasksAgg.Repository;

namespace TaskManagement.Application.Tasks.Commands.Edit
{
	 public class EditTaskCommand : TaskCommand, IRequest<OperationResult>
	 {
		  public Guid Id { get; set; }


		  public class EditTaskCommandHandler : IRequestHandler<EditTaskCommand, OperationResult>
		  {
			   private readonly ITaskRepository _taskRepository;
			   public EditTaskCommandHandler(ITaskRepository taskRepository)
			   {
					_taskRepository = taskRepository;
			   }

			   public async Task<OperationResult> Handle(EditTaskCommand request, CancellationToken cancellationToken)
			   {
					var currentTask = await _taskRepository.GetTracking(request.Id);
					if (currentTask == null)
						 return OperationResult.NotFound();

					currentTask.UpdateDescription(request.Description);
					currentTask.UpdateName(request.Name);

					await _taskRepository.Save();
					return OperationResult.Success();

			   }
		  }
	 }
}
