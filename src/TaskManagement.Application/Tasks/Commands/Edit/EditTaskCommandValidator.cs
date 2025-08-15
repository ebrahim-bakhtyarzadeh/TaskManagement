using FluentValidation;
using TaskManagement.Application.Tasks.Commands.Common;

namespace TaskManagement.Application.Tasks.Commands.Edit
{
	 public class EditTaskCommandValidator : AbstractValidator<EditTaskCommand>
	 {
		  public EditTaskCommandValidator() =>
		 Include(new TaskCommandValidator());
	 }
}
