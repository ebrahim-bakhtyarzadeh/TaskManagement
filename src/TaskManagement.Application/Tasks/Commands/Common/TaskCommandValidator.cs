using FluentValidation;
using TaskManagement.Domain.Models.TasksAgg.Constants;

namespace TaskManagement.Application.Tasks.Commands.Common
{
	 public class TaskCommandValidator : AbstractValidator<TaskCommand>
	 {
		  public TaskCommandValidator()
		  {
			   RuleFor(c => c.Name).NotEmpty().WithMessage("نام وظیفه را حتما ثبت کنید").Length(TaskConstant.Task.MinNameLength, TaskConstant.Task.MaxNameLength)
				 .WithMessage($"نام وظیفه باید بین {TaskConstant.Task.MinNameLength} و {TaskConstant.Task.MaxNameLength} باشد");

			   RuleFor(c => c.Description).NotEmpty().WithMessage("توضیحات وظیفه را وارد کنید")
					.Length(TaskConstant.Task.MinDescriptionLength, TaskConstant.Task.MaxDescriptionLength)
				 .WithMessage($"توضیحات وظیفه باید بین {TaskConstant.Task.MinDescriptionLength} و {TaskConstant.Task.MaxDescriptionLength} باشد"); ;
		  }
	 }
}
