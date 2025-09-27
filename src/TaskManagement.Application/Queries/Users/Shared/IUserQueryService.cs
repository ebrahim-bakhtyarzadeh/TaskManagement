using TaskManagement.Application.Queries.Users.DTOs;

namespace TaskManagement.Application.Queries.Users.Shared
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
