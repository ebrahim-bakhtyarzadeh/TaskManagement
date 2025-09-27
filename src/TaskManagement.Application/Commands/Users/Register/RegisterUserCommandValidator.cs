using FluentValidation;
using TaskManagement.Application.Commands.Users.Common;

namespace TaskManagement.Application.Commands.Users.Register
{
	 public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
	 {
		  public RegisterUserCommandValidator() => Include(new UserCommandValidator());
	 }
}
