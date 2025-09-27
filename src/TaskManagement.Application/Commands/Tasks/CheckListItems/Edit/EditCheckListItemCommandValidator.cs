using FluentValidation;
using TaskManagement.Application.Commands.Tasks.CheckListItems.Common;

namespace TaskManagement.Application.Commands.Tasks.CheckListItems.Edit
{
	 public class EditCheckListItemCommandValidator : AbstractValidator<EditCheckListItemCommand>
	 {
		  public EditCheckListItemCommandValidator() => Include(new CheckListItemCommandValidator());

	 }
}
