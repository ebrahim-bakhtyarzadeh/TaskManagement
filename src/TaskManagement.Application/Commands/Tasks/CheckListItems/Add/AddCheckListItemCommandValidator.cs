using FluentValidation;
using TaskManagement.Application.Tasks.Commands.CheckListItems.Common;

namespace TaskManagement.Application.Commands.Tasks.CheckListItems.Add
{
	 public class AddCheckListItemCommandValidator : AbstractValidator<AddCheckListItemCommand>
	 {
		  public AddCheckListItemCommandValidator() => Include(new CheckListItemCommandValidator());

	 }
}
