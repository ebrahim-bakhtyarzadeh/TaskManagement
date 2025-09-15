using FluentValidation;
using TaskManagement.Application.Tasks.Commands._Common;

namespace TaskManagement.Application.Tasks.Commands.Edit
{
	 public class EditTaskCommandValidator : AbstractValidator<EditTaskCommand>
	 {
		  public EditTaskCommandValidator() =>
		 Include(new TaskCommandValidator());
	 }
}
