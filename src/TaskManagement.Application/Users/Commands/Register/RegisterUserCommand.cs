using Common.Application.Result;
using Common.Application.SecurityUtil;
using MediatR;
using TaskManagement.Application.Users.Commands.Common;
using TaskManagement.Domain.Models.UsersAgg.Models;
using TaskManagement.Domain.Models.UsersAgg.Repository;
using TaskManagement.Domain.Models.UsersAgg.Services;

namespace TaskManagement.Application.Users.Commands.Register
{
	 public class RegisterUserCommand : UserCommand, IRequest<OperationResult>
	 {

		  public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, OperationResult>
		  {

			   private readonly IUserRepository _userRepository;
			   private readonly IUserDomainService _userDomainService;
			   public RegisterUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
			   {
					_userRepository = userRepository;
					_userDomainService = userDomainService;
			   }

			   public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
			   {
					var newUser = User.RegisterUser(request.Email, request.PhoneNumber, Sha256Hasher.Hash(request.Password), _userDomainService);

					_userRepository.Add(newUser);
					await _userRepository.Save();

					return OperationResult.Success("ثبت نام با موفقیت انجام شد");

			   }
		  }
	 }
}
