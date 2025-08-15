using FluentValidation;
using TaskManagement.Application.Users.Commands.Common;

namespace TaskManagement.Application.Users.Commands.Register
{
	 public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
	 {
		  public RegisterUserCommandValidator() => Include(new UserCommandValidator());
	 }
}
