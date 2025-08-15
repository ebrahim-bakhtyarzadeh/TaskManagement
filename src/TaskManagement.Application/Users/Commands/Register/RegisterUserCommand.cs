using Application.Common.Result;
using Application.Common.SecurityUtil;
using MediatR;
using TaskManagement.Application.Users.Commands.Common;
using TaskManagement.Domain.Models.UsersAgg.Models;
using TaskManagement.Domain.Models.UsersAgg.Repository;
using TaskManagement.Domain.Models.UsersAgg.Services;

namespace TaskManagement.Application.Users.Commands.Register
{
	 public class RegisterUserCommand : UserCommand, IRequest<UseCaseResult>
	 {

		  public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UseCaseResult>
		  {

			   private readonly IUserRepository _userRepository;
			   private readonly IUserDomainService _userDomainService;
			   public RegisterUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
			   {
					_userRepository = userRepository;
					_userDomainService = userDomainService;
			   }

			   public async Task<UseCaseResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
			   {
					var newUser = User.RegisterUser(request.Email, request.PhoneNumber, Sha256Hasher.Hash(request.Password), _userDomainService);

					_userRepository.Add(newUser);
					await _userRepository.Save();

					return UseCaseResult.Success("ثبت نام با موفقیت انجام شد");

			   }
		  }
	 }
}
