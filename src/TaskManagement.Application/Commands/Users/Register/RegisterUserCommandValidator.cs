using FluentValidation;
using TaskManagement.Application.Users.Commands.Common;

namespace TaskManagement.Application.Commands.Users.Register
{
	 public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
	 {
		  public RegisterUserCommandValidator() => Include(new UserCommandValidator());
	 }
}
