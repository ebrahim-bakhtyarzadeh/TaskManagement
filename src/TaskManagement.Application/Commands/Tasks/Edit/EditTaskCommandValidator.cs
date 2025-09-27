using FluentValidation;
using TaskManagement.Application.Commands.Tasks._Common;

namespace TaskManagement.Application.Commands.Tasks.Edit
{
	 public class EditTaskCommandValidator : AbstractValidator<EditTaskCommand>
	 {
		  public EditTaskCommandValidator() =>
		 Include(new TaskCommandValidator());
	 }
}
