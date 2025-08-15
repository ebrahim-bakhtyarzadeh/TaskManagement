using Application.Common.Result;
using MediatR;
using TaskManagement.Application.Tasks.Commands.Common;
using TaskManagement.Domain.Models.TasksAgg.Repository;

namespace TaskManagement.Application.Tasks.Commands.Edit
{
	 public class EditTaskCommand : TaskCommand, IRequest<UseCaseResult>
	 {
		  public Guid Id { get; set; }


		  public class EditTaskCommandHandler : IRequestHandler<EditTaskCommand, UseCaseResult>
		  {
			   private readonly ITaskRepository _taskRepository;
			   public EditTaskCommandHandler(ITaskRepository taskRepository)
			   {
					_taskRepository = taskRepository;
			   }

			   public async Task<UseCaseResult> Handle(EditTaskCommand request, CancellationToken cancellationToken)
			   {
					var currentTask = await _taskRepository.GetTracking(request.Id);
					if (currentTask == null)
						 return UseCaseResult.NotFound();

					currentTask.UpdateDescription(request.Description);
					currentTask.UpdateName(request.Name);

					await _taskRepository.Save();
					return UseCaseResult.Success();

			   }
		  }
	 }
}
