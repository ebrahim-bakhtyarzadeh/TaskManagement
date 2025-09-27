using FluentValidation;
using TaskManagement.Domain.TasksAgg.Constants;

namespace TaskManagement.Application.Commands.Tasks.CheckListItems.Common
{
	 public class CheckListItemCommandValidator : AbstractValidator<CheckListItemCommand>
	 {
		  public CheckListItemCommandValidator()
		  {
			   RuleFor(c => c.ItemName).NotEmpty().WithMessage("نام ایتم را حتما ثبت کنید").Length(Constants.Task.MinNameLength, Constants.Task.MaxNameLength)
				.WithMessage($"نام ایتم باید بین {Constants.Task.MinNameLength} و {Constants.Task.MaxNameLength} باشد");

			   RuleFor(c => c.ItemDescription).NotEmpty().WithMessage("توضیحات ایتم را وارد کنید")
					.Length(Constants.Task.MinDescriptionLength, Constants.Task.MaxDescriptionLength)
				 .WithMessage($"توضیحات ایتم باید بین {Constants.Task.MinDescriptionLength} و {Constants.Task.MaxDescriptionLength} باشد"); ;
		  }
	 }
}
