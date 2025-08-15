using FluentValidation;
using TaskManagement.Domain.Models.TasksAgg.Constants;

namespace TaskManagement.Application.Tasks.Commands.CheckListItems.Common
{
	 public class CheckListItemCommandValidator : AbstractValidator<CheckListItemCommand>
	 {
		  public CheckListItemCommandValidator()
		  {
			   RuleFor(c => c.ItemName).NotEmpty().WithMessage("نام ایتم را حتما ثبت کنید").Length(TaskConstant.Task.MinNameLength, TaskConstant.Task.MaxNameLength)
				.WithMessage($"نام ایتم باید بین {TaskConstant.Task.MinNameLength} و {TaskConstant.Task.MaxNameLength} باشد");

			   RuleFor(c => c.ItemDescription).NotEmpty().WithMessage("توضیحات ایتم را وارد کنید")
					.Length(TaskConstant.Task.MinDescriptionLength, TaskConstant.Task.MaxDescriptionLength)
				 .WithMessage($"توضیحات ایتم باید بین {TaskConstant.Task.MinDescriptionLength} و {TaskConstant.Task.MaxDescriptionLength} باشد"); ;
		  }
	 }
}
