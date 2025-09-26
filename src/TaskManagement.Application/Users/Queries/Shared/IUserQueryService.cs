using TaskManagement.Application.Users.Queries.DTOs;

namespace TaskManagement.Application.Users.Queries.Shared
{
	 public interface IUserQueryService
	 {
		  Task<UserDto?> GetUserById(Guid userId, CancellationToken cancellationToken);
		  public Task<UserTokenDto> GetUserTokenByJwtToken(Guid userId, string jwtToken);


		  Task<List<UserDto>> GetActiveUsers(CancellationToken cancellationToken);
		  Task<List<UserDto>> GetAllUsers(CancellationToken cancellationToken);
		  Task<UserDto> GetUserByPhoneNumber(string phoneNumber, CancellationToken cancellationToken);

	 }
}
