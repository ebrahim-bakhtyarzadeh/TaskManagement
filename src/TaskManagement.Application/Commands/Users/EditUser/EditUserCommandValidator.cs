using FluentValidation;
using TaskManagement.Application.Commands.Users.Common;
using TaskManagement.Domain.UsersAgg.Constants;

namespace TaskManagement.Application.Commands.Users.EditUser
{
	 public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
	 {
		  public EditUserCommandValidator()
		  {
			   Include(new UserCommandValidator());

			   RuleFor(c => c.FirstName).NotEmpty().WithMessage("نام خود را وارد کنید")
					.Length(UserConstant.User.MinFirstNameLength, UserConstant.User.MaxFirstNameLength).WithMessage($"نام شما باید بین{UserConstant.User.MinFirstNameLength} و {UserConstant.User.MaxFirstNameLength} باشد");

			   RuleFor(c => c.LastName).NotEmpty().WithMessage("نام خود را وارد کنید")
				   .Length(UserConstant.User.MinLastNameLength, UserConstant.User.MaxLastNameLength).WithMessage($"نام خانوادگی شما باید بین{UserConstant.User.MinLastNameLength} و {UserConstant.User.MaxLastNameLength} باشد");
		  }

	 }
}
