using FluentValidation;
using TaskManagement.Application.Commands.Tasks._Common;

namespace TaskManagement.Application.Commands.Tasks.Create
{
	 public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
	 {
		  public CreateTaskCommandValidator() =>
			   Include(new TaskCommandValidator());

	 }
}
