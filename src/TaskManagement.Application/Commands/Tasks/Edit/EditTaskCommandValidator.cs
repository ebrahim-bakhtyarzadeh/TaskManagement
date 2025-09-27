using FluentValidation;
using TaskManagement.Application.Tasks.Commands._Common;

namespace TaskManagement.Application.Commands.Tasks.Edit
{
	 public class EditTaskCommandValidator : AbstractValidator<EditTaskCommand>
	 {
		  public EditTaskCommandValidator() =>
		 Include(new TaskCommandValidator());
	 }
}
