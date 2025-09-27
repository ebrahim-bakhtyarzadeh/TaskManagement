using FluentValidation;
using TaskManagement.Domain.UsersAgg.Constants;

namespace TaskManagement.Application.Commands.Users.Common
{
	 public class UserCommandValidator : AbstractValidator<UserCommand>
	 {
		  public UserCommandValidator()
		  {
			   RuleFor(c => c.Password).NotEmpty().WithMessage("لطفا رمز عبور را وارد کنید");
			   RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage("شماره تماس باید وارد شود")
					.Length(UserConstant.User.PhoneNumberLenght).WithMessage("شماره تماس باید 11 رقم باشد");
			   RuleFor(c => c.Email).NotEmpty().WithMessage("ایمیل باید وارد شود");
		  }
	 }
}
