using FluentValidation;
using TaskManagement.Application.Tasks.Commands.CheckListItems.Common;

namespace TaskManagement.Application.Tasks.Commands.CheckListItems.Edit
{
	 public class EditCheckListItemCommandValidator : AbstractValidator<EditCheckListItemCommand>
	 {
		  public EditCheckListItemCommandValidator() => Include(new CheckListItemCommandValidator());

	 }
}
