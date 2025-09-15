using Common.Application.Result;
using Common.Application.SecurityUtil;
using MediatR;
using TaskManagement.Application.Users.Commands.Common;
using TaskManagement.Domain.Models.UsersAgg.Repository;
using TaskManagement.Domain.Models.UsersAgg.Services;

namespace TaskManagement.Application.Users.Commands.EditUser
{
	 public class EditUserCommand : UserCommand, IRequest<OperationResult>
	 {
		  public EditUserCommand(string firstName, string lastName, Guid userId)
		  {
			   FirstName = firstName;
			   LastName = lastName;
			   UserId = userId;
		  }
		  public Guid UserId { get; set; }
		  public string FirstName { get; set; }
		  public string LastName { get; set; }

		  public class EditUserCommandHandler : IRequestHandler<EditUserCommand, OperationResult>
		  {
			   private readonly IUserRepository _userRepository;
			   private readonly IUserDomainService _userDomainService;

			   public EditUserCommandHandler(IUserRepository userRepository, IUserDomainService userDomainService)
			   {
					_userRepository = userRepository;
					_userDomainService = userDomainService;
			   }

			   public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
			   {
					var user = await _userRepository.GetTracking(request.UserId);
					if (user is null)
						 return OperationResult.NotFound("کاربری با این شناسه یاقت نشد");

					user.Edit(request.FirstName, request.LastName, request.PhoneNumber, request.Email, Sha256Hasher.Hash(request.Password), _userDomainService);
					await _userRepository.Save();
					return OperationResult.Success("اطلاعات شما با موفقیت تغییر کرد");
			   }
		  }
	 }
}
