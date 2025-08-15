using FluentValidation;
using TaskManagement.Application.Tasks.Commands.Common;

namespace TaskManagement.Application.Tasks.Commands.Create
{
	 public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
	 {
		  public CreateTaskCommandValidator() =>
			   Include(new TaskCommandValidator());

	 }
}
