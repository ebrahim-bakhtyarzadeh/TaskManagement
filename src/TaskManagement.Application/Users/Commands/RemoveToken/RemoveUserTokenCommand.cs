using Common.Application.Result;
using MediatR;
using TaskManagement.Domain.Models.UsersAgg.Repository;

namespace TaskManagement.Application.Users.Commands.RemoveToken
{
	 public class RemoveUserTokenCommand : IRequest<OperationResult>
	 {
		  public Guid UserId { get; set; }
		  public Guid TokenId { get; set; }


		  public class RemoveUserTokenCommandHandler : IRequestHandler<RemoveUserTokenCommand, OperationResult>
		  {

			   private readonly IUserRepository _userRepository;

			   public RemoveUserTokenCommandHandler(IUserRepository userRepository)
			   {
					_userRepository = userRepository;
			   }

			   public async Task<OperationResult> Handle(RemoveUserTokenCommand request, CancellationToken cancellationToken)
			   {
					var user = await _userRepository.GetTracking(request.UserId);
					if (user == null)
						 return OperationResult.NotFound("کاربری با این شناسه یافت نشد");

					user.RemoveToken(request.TokenId);
					await _userRepository.Save();
					return OperationResult.Success();

			   }
		  }
	 }
}
