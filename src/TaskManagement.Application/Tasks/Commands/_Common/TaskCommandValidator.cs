using FluentValidation;
using TaskManagement.Domain.TasksAgg.Constants;

namespace TaskManagement.Application.Tasks.Commands._Common
{
	 public class TaskCommandValidator : AbstractValidator<TaskCommand>
	 {
		  public TaskCommandValidator()
		  {
			   RuleFor(c => c.Name).NotEmpty().WithMessage("نام وظیفه را حتما ثبت کنید").Length(Constants.Task.MinNameLength, Constants.Task.MaxNameLength)
				 .WithMessage($"نام وظیفه باید بین {Constants.Task.MinNameLength} و {Constants.Task.MaxNameLength} باشد");

			   RuleFor(c => c.Description).NotEmpty().WithMessage("توضیحات وظیفه را وارد کنید")
					.Length(Constants.Task.MinDescriptionLength, Constants.Task.MaxDescriptionLength)
				 .WithMessage($"توضیحات وظیفه باید بین {Constants.Task.MinDescriptionLength} و {Constants.Task.MaxDescriptionLength} باشد"); ;
		  }
	 }
}
