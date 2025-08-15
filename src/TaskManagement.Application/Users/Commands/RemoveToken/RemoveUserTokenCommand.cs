using Application.Common.Result;
using MediatR;
using TaskManagement.Domain.Models.UsersAgg.Repository;

namespace TaskManagement.Application.Users.Commands.RemoveToken
{
	 public class RemoveUserTokenCommand : IRequest<UseCaseResult>
	 {
		  public Guid UserId { get; set; }
		  public Guid TokenId { get; set; }


		  public class RemoveUserTokenCommandHandler : IRequestHandler<RemoveUserTokenCommand, UseCaseResult>
		  {

			   private readonly IUserRepository _userRepository;

			   public RemoveUserTokenCommandHandler(IUserRepository userRepository)
			   {
					_userRepository = userRepository;
			   }

			   public async Task<UseCaseResult> Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
			   {
					var user = await _userRepository.GetTracking(request.UserId);
					if (user == null)
						 return UseCaseResult.NotFound("کاربری با این شناسه یافت نشد");

					user.RemoveToken(request.TokenId);
					await _userRepository.Save();
					return UseCaseResult.Success();

			   }
		  }
	 }
}
