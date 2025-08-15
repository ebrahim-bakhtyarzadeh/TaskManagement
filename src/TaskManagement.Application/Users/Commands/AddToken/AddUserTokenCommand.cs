using Application.Common.Result;
using MediatR;
using TaskManagement.Application.Users.Commands.Common;
using TaskManagement.Domain.Models.UsersAgg.Repository;

namespace TaskManagement.Application.Users.Commands.AddToken
{
	 public class AddUserTokenCommand : UserToken, IRequest<UseCaseResult>
	 {
		  public AddUserTokenCommand(Guid userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate) : base(userId, hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate)
		  {
		  }


		  public class AddUserTokenCommandHandler : IRequestHandler<AddUserTokenCommand, UseCaseResult>
		  {
			   private readonly IUserRepository _userRepository;

			   public AddUserTokenCommandHandler(IUserRepository userRepository)
			   {
					_userRepository = userRepository;
			   }

			   public async Task<UseCaseResult> Handle(AddUserTokenCommand request, CancellationToken cancellationToken)
			   {
					var user = await _userRepository.GetTracking(request.UserId);

					if (user is null)
						 return UseCaseResult.NotFound("کاربر مورد نظر یافت نشد");

					user.AddToken(request.HashJwtToken, request.HashRefreshToken, request.TokenExpireDate, request.RefreshTokenExpireDate);

					await _userRepository.Save();
					return UseCaseResult.Success();

			   }
		  }
	 }

}
