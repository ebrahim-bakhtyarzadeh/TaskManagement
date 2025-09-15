using FluentValidation;
using TaskManagement.Application.Tasks.Commands._Common;

namespace TaskManagement.Application.Tasks.Commands.Create
{
	 public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
	 {
		  public CreateTaskCommandValidator() =>
			   Include(new TaskCommandValidator());

	 }
}
